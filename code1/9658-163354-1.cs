    /*
     * Copyright (C) 2002-2007 Stephen Ostermiller
     * http://ostermiller.org/contact.pl?regarding=Java+Utilities
     *
     * This program is free software; you can redistribute it and/or modify
     * it under the terms of the GNU General Public License as published by
     * the Free Software Foundation; either version 2 of the License, or
     * (at your option) any later version.
     *
     * This program is distributed in the hope that it will be useful,
     * but WITHOUT ANY WARRANTY; without even the implied warranty of
     * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
     * GNU General Public License for more details.
     *
     * See COPYING.TXT for details.
     */
    public class SignificantFigures
    {
        private String original;
        private StringBuilder _digits;
        private int mantissa = -1;
        private bool sign = true;
        private bool isZero = false;
        private bool useScientificNotation = true;
        public SignificantFigures(String number)
        {
            original = number;
            Parse(original);
        }
        public SignificantFigures(double number)
        {
            original = Convert.ToString(number);
            try
            {
                Parse(original);
            }
            catch (Exception nfe)
            {
                _digits = null;
            }
        }
        public bool UseScientificNotation
        {
            get { return useScientificNotation; }
            set { useScientificNotation = value; }
        }
        public int GetNumberSignificantFigures()
        {
            if (_digits == null) return 0;
            return _digits.Length;
        }
        public SignificantFigures SetLSD(int place)
        {
            SetLMSD(place, Int32.MinValue);
            return this;
        }
        public SignificantFigures SetLMSD(int leastPlace, int mostPlace)
        {
            if (_digits != null && leastPlace != Int32.MinValue)
            {
                int significantFigures = _digits.Length;
                int current = mantissa - significantFigures + 1;
                int newLength = significantFigures - leastPlace + current;
                if (newLength <= 0)
                {
                    if (mostPlace == Int32.MinValue)
                    {
                        original = "NaN";
                        _digits = null;
                    }
                    else
                    {
                        newLength = mostPlace - leastPlace + 1;
                        _digits.Length = newLength;
                        mantissa = leastPlace;
                        for (int i = 0; i < newLength; i++)
                        {
                            _digits[i] = '0';
                        }
                        isZero = true;
                        sign = true;
                    }
                }
                else
                {
                    _digits.Length = newLength;
                    for (int i = significantFigures; i < newLength; i++)
                    {
                        _digits[i] = '0';
                    }
                }
            }
            return this;
        }
        public int GetLSD()
        {
            if (_digits == null) return Int32.MinValue;
            return mantissa - _digits.Length + 1;
        }
        public int GetMSD()
        {
            if (_digits == null) return Int32.MinValue;
            return mantissa + 1;
        }
        public override String ToString()
        {
            if (_digits == null) return original;
            StringBuilder digits = new StringBuilder(this._digits.ToString());
            int length = digits.Length;
            if ((mantissa <= -4 || mantissa >= 7 ||
                 (mantissa >= length &&
                  digits[digits.Length - 1] == '0') ||
                 (isZero && mantissa != 0)) && useScientificNotation)
            {
                // use scientific notation.
                if (length > 1)
                {
                    digits.Insert(1, '.');
                }
                if (mantissa != 0)
                {
                    digits.Append("E" + mantissa);
                }
            }
            else if (mantissa <= -1)
            {
                digits.Insert(0, "0.");
                for (int i = mantissa; i < -1; i++)
                {
                    digits.Insert(2, '0');
                }
            }
            else if (mantissa + 1 == length)
            {
                if (length > 1 && digits[digits.Length - 1] == '0')
                {
                    digits.Append('.');
                }
            }
            else if (mantissa < length)
            {
                digits.Insert(mantissa + 1, '.');
            }
            else
            {
                for (int i = length; i <= mantissa; i++)
                {
                    digits.Append('0');
                }
            }
            if (!sign)
            {
                digits.Insert(0, '-');
            }
            return digits.ToString();
        }
        public String ToScientificNotation()
        {
            if (_digits == null) return original;
            StringBuilder digits = new StringBuilder(this._digits.ToString());
            int length = digits.Length;
            if (length > 1)
            {
                digits.Insert(1, '.');
            }
            if (mantissa != 0)
            {
                digits.Append("E" + mantissa);
            }
            if (!sign)
            {
                digits.Insert(0, '-');
            }
            return digits.ToString();
        }
        private const int INITIAL = 0;
        private const int LEADZEROS = 1;
        private const int MIDZEROS = 2;
        private const int DIGITS = 3;
        private const int LEADZEROSDOT = 4;
        private const int DIGITSDOT = 5;
        private const int MANTISSA = 6;
        private const int MANTISSADIGIT = 7;
        private void Parse(String number)
        {
            int length = number.Length;
            _digits = new StringBuilder(length);
            int state = INITIAL;
            int mantissaStart = -1;
            bool foundMantissaDigit = false;
            // sometimes we don't know if a zero will be
            // significant or not when it is encountered.
            // keep track of the number of them so that
            // the all can be made significant if we find
            // out that they are.
            int zeroCount = 0;
            int leadZeroCount = 0;
            for (int i = 0; i < length; i++)
            {
                char c = number[i];
                switch (c)
                {
                    case '.':
                        {
                            switch (state)
                            {
                                case INITIAL:
                                case LEADZEROS:
                                    {
                                        state = LEADZEROSDOT;
                                    }
                                    break;
                                case MIDZEROS:
                                    {
                                        // we now know that these zeros
                                        // are more than just trailing place holders.
                                        for (int j = 0; j < zeroCount; j++)
                                        {
                                            _digits.Append('0');
                                        }
                                        zeroCount = 0;
                                        state = DIGITSDOT;
                                    }
                                    break;
                                case DIGITS:
                                    {
                                        state = DIGITSDOT;
                                    }
                                    break;
                                default:
                                    {
                                        throw new Exception(
                                            "Unexpected character '" + c + "' at position " + i
                                            );
                                    }
                            }
                        }
                        break;
                    case '+':
                        {
                            switch (state)
                            {
                                case INITIAL:
                                    {
                                        sign = true;
                                        state = LEADZEROS;
                                    }
                                    break;
                                case MANTISSA:
                                    {
                                        state = MANTISSADIGIT;
                                    }
                                    break;
                                default:
                                    {
                                        throw new Exception(
                                            "Unexpected character '" + c + "' at position " + i
                                            );
                                    }
                            }
                        }
                        break;
                    case '-':
                        {
                            switch (state)
                            {
                                case INITIAL:
                                    {
                                        sign = false;
                                        state = LEADZEROS;
                                    }
                                    break;
                                case MANTISSA:
                                    {
                                        state = MANTISSADIGIT;
                                    }
                                    break;
                                default:
                                    {
                                        throw new Exception(
                                            "Unexpected character '" + c + "' at position " + i
                                            );
                                    }
                            }
                        }
                        break;
                    case '0':
                        {
                            switch (state)
                            {
                                case INITIAL:
                                case LEADZEROS:
                                    {
                                        // only significant if number
                                        // is all zeros.
                                        zeroCount++;
                                        leadZeroCount++;
                                        state = LEADZEROS;
                                    }
                                    break;
                                case MIDZEROS:
                                case DIGITS:
                                    {
                                        // only significant if followed
                                        // by a decimal point or nonzero digit.
                                        mantissa++;
                                        zeroCount++;
                                        state = MIDZEROS;
                                    }
                                    break;
                                case LEADZEROSDOT:
                                    {
                                        // only significant if number
                                        // is all zeros.
                                        mantissa--;
                                        zeroCount++;
                                        state = LEADZEROSDOT;
                                    }
                                    break;
                                case DIGITSDOT:
                                    {
                                        // non-leading zeros after
                                        // a decimal point are always
                                        // significant.
                                        _digits.Append(c);
                                    }
                                    break;
                                case MANTISSA:
                                case MANTISSADIGIT:
                                    {
                                        foundMantissaDigit = true;
                                        state = MANTISSADIGIT;
                                    }
                                    break;
                                default:
                                    {
                                        throw new Exception(
                                            "Unexpected character '" + c + "' at position " + i
                                            );
                                    }
                            }
                        }
                        break;
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        {
                            switch (state)
                            {
                                case INITIAL:
                                case LEADZEROS:
                                case DIGITS:
                                    {
                                        zeroCount = 0;
                                        _digits.Append(c);
                                        mantissa++;
                                        state = DIGITS;
                                    }
                                    break;
                                case MIDZEROS:
                                    {
                                        // we now know that these zeros
                                        // are more than just trailing place holders.
                                        for (int j = 0; j < zeroCount; j++)
                                        {
                                            _digits.Append('0');
                                        }
                                        zeroCount = 0;
                                        _digits.Append(c);
                                        mantissa++;
                                        state = DIGITS;
                                    }
                                    break;
                                case LEADZEROSDOT:
                                case DIGITSDOT:
                                    {
                                        zeroCount = 0;
                                        _digits.Append(c);
                                        state = DIGITSDOT;
                                    }
                                    break;
                                case MANTISSA:
                                case MANTISSADIGIT:
                                    {
                                        state = MANTISSADIGIT;
                                        foundMantissaDigit = true;
                                    }
                                    break;
                                default:
                                    {
                                        throw new Exception(
                                            "Unexpected character '" + c + "' at position " + i
                                            );
                                    }
                            }
                        }
                        break;
                    case 'E':
                    case 'e':
                        {
                            switch (state)
                            {
                                case INITIAL:
                                case LEADZEROS:
                                case DIGITS:
                                case LEADZEROSDOT:
                                case DIGITSDOT:
                                    {
                                        // record the starting point of the mantissa
                                        // so we can do a substring to get it back later
                                        mantissaStart = i + 1;
                                        state = MANTISSA;
                                    }
                                    break;
                                default:
                                    {
                                        throw new Exception(
                                            "Unexpected character '" + c + "' at position " + i
                                            );
                                    }
                            }
                        }
                        break;
                    default:
                        {
                            throw new Exception(
                                "Unexpected character '" + c + "' at position " + i
                                );
                        }
                }
            }
            if (mantissaStart != -1)
            {
                // if we had found an 'E'
                if (!foundMantissaDigit)
                {
                    // we didn't actually find a mantissa to go with.
                    throw new Exception(
                        "No digits in mantissa."
                        );
                }
                // parse the mantissa.
                mantissa += Convert.ToInt32(number.Substring(mantissaStart));
            }
            if (_digits.Length == 0)
            {
                if (zeroCount > 0)
                {
                    // if nothing but zeros all zeros are significant.
                    for (int j = 0; j < zeroCount; j++)
                    {
                        _digits.Append('0');
                    }
                    mantissa += leadZeroCount;
                    isZero = true;
                    sign = true;
                }
                else
                {
                    // a hack to catch some cases that we could catch
                    // by adding a ton of extra states.  Things like:
                    // "e2" "+e2" "+." "." "+" etc.
                    throw new Exception(
                        "No digits in number."
                        );
                }
            }
        }
        public SignificantFigures SetNumberSignificantFigures(int significantFigures)
        {
            if (significantFigures <= 0)
                throw new ArgumentException("Desired number of significant figures must be positive.");
            if (_digits != null)
            {
                int length = _digits.Length;
                if (length < significantFigures)
                {
                    // number is not long enough, pad it with zeros.
                    for (int i = length; i < significantFigures; i++)
                    {
                        _digits.Append('0');
                    }
                }
                else if (length > significantFigures)
                {
                    // number is too long chop some of it off with rounding.
                    bool addOne; // we need to round up if true.
                    char firstInSig = _digits[significantFigures];
                    if (firstInSig < '5')
                    {
                        // first non-significant digit less than five, round down.
                        addOne = false;
                    }
                    else if (firstInSig == '5')
                    {
                        // first non-significant digit equal to five
                        addOne = false;
                        for (int i = significantFigures + 1; !addOne && i < length; i++)
                        {
                            // if its followed by any non-zero digits, round up.
                            if (_digits[i] != '0')
                            {
                                addOne = true;
                            }
                        }
                        if (!addOne)
                        {
                            // if it was not followed by non-zero digits
                            // if the last significant digit is odd round up
                            // if the last significant digit is even round down
                            addOne = (_digits[significantFigures - 1] & 1) == 1;
                        }
                    }
                    else
                    {
                        // first non-significant digit greater than five, round up.
                        addOne = true;
                    }
                    // loop to add one (and carry a one if added to a nine)
                    // to the last significant digit
                    for (int i = significantFigures - 1; addOne && i >= 0; i--)
                    {
                        char digit = _digits[i];
                        if (digit < '9')
                        {
                            _digits[i] = (char) (digit + 1);
                            addOne = false;
                        }
                        else
                        {
                            _digits[i] = '0';
                        }
                    }
                    if (addOne)
                    {
                        // if the number was all nines
                        _digits.Insert(0, '1');
                        mantissa++;
                    }
                    // chop it to the correct number of figures.
                    _digits.Length = significantFigures;
                }
            }
            return this;
        }
        public double ToDouble()
        {
            return Convert.ToDouble(original);
        }
        public static String Format(double number, int significantFigures)
        {
            SignificantFigures sf = new SignificantFigures(number);
            sf.SetNumberSignificantFigures(significantFigures);
            return sf.ToString();
        }
    }
