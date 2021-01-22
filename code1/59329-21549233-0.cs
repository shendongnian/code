    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace StackOverflow
    {
        /// <summary>
        /// Contains methods used to convert numbers between base-10 and another numbering system.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This conversion class makes use of a set of characters that represent the digits used by the target
        /// numbering system. For example, binary would use the digits 0 and 1, whereas hex would use the digits
        /// 0 through 9 plus A through F. The digits do not have to be numerals.
        /// </para>
        /// <para>
        /// The first digit in the sequence has special significance. If the number passed to the
        /// <see cref="StringToBase10"/> method has leading digits that match the first digit, then those leading
        /// digits will effectively be 'lost' during conversion. Much of the time this won't matter. For example,
        /// "0F" hex will be converted to 15 decimal, but when converted back to hex it will become simply "F",
        /// losing the leading "0". However, if the set of digits was A through Z, and the number "ABC" was
        /// converted to base-10 and back again, then the leading "A" would be lost. The <see cref="System.Boolean"/>
        /// flag passed to the constructor allows 'round-tripping' behaviour to be supported, which will prevent
        /// leading digits from being lost during conversion.
        /// </para>
        /// <para>
        /// Note that numeric overflow is probable when using longer strings and larger digit sets.
        /// </para>
        /// </remarks>
        public class Base10Converter
        {
            const char NullDigit = '\0';
            public Base10Converter(string digits, bool shouldSupportRoundTripping = false)
                : this(digits.ToCharArray(), shouldSupportRoundTripping)
            {
            }
            public Base10Converter(IEnumerable<char> digits, bool shouldSupportRoundTripping = false)
            {
                if (digits == null)
                {
                    throw new ArgumentNullException("digits");
                }
                if (digits.Count() == 0)
                {
                    throw new ArgumentException(
                        message: "The sequence is empty.",
                        paramName: "digits"
                        );
                }
                if (!digits.Distinct().SequenceEqual(digits))
                {
                    throw new ArgumentException(
                        message: "There are duplicate characters in the sequence.",
                        paramName: "digits"
                        );
                }
                if (shouldSupportRoundTripping)
                {
                    digits = (new[] { NullDigit }).Concat(digits);
                }
                _digitToIndexMap =
                    digits
                    .Select((digit, index) => new { digit, index })
                    .ToDictionary(keySelector: x => x.digit, elementSelector: x => x.index);
                _radix = _digitToIndexMap.Count;
                _indexToDigitMap =
                    _digitToIndexMap
                    .ToDictionary(keySelector: x => x.Value, elementSelector: x => x.Key);
            }
            readonly Dictionary<char, int> _digitToIndexMap;
            readonly Dictionary<int, char> _indexToDigitMap;
            readonly int _radix;
            public long StringToBase10(string number)
            {
                Func<char, int, long> selector =
                    (c, i) =>
                    {
                        int power = number.Length - i - 1;
                        int digitIndex;
                        if (!_digitToIndexMap.TryGetValue(c, out digitIndex))
                        {
                            throw new ArgumentException(
                                message: String.Format("Number contains an invalid digit '{0}' at position {1}.", c, i),
                                paramName: "number"
                                );
                        }
                        return Convert.ToInt64(digitIndex * Math.Pow(_radix, power));
                    };
                return number.Select(selector).Sum();
            }
            public string Base10ToString(long number)
            {
                if (number < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        message: "Value cannot be negative.",
                        paramName: "number"
                        );
                }
                string text = string.Empty;
                long remainder;
                do
                {
                    number = Math.DivRem(number, _radix, out remainder);
                    char digit;
                    if (!_indexToDigitMap.TryGetValue((int) remainder, out digit) || digit == NullDigit)
                    {
                        throw new ArgumentException(
                            message: "Value cannot be converted given the set of digits used by this converter.",
                            paramName: "number"
                            );
                    }
                    text = digit + text;
                }
                while (number > 0);
                return text;
            }
        }
    }
