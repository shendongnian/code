            Double exponentbase = 129d;
            Double exponent = real48[0] - exponentbase; // The exponent is offest so deduct the base.
            // Now Calculate the mantissa
            Double mantissa = 0.0;
            Double value = 1.0;
            // For Each Byte.
            for (int i = 5; i >= 1; i--)
            {
                int startbit = 7;
                if (i == 5)
                { startbit = 6; } //skip the sign bit.
                //For Each Bit
                for (int j = startbit; j >= 0; j--)
                {
                    value = value / 2;// Each bit is worth half the next bit but we're going backwards.
                    if (((real48[i] >> j) & 1) == 1) //if this bit is set.
                    {
                        mantissa += value; // add the value.
                    }
                }
            }
            if (mantissa == 1.0 && real48[0] == 0) // Test for null value
                return 0.0;
            if ((real48[5] & 0x80) == 1) // Sign bit check
                mantissa = -mantissa;
            return (1 + mantissa) * Math.Pow(2.0, exponent);
