     //This seems to be the layout of the Real48 bits where
            //E = Exponent
            //S = Sign bit
            //F = Fraction
            //EEEEEEEE FFFFFFFF FFFFFFFF FFFFFFFF FFFFFFFF SFFFFFFF
            //12345678 12345678 12345678 12345678 12345678 12345678
            Double exponentbase = 129d;  // The exponent is offest by 129
            Double exponent = real48[0] - exponentbase; // deduct the offest. 
            // Calculate the mantissa 
            Double mantissa = 0.0;
            Double value = 1.0;
            // For Each Byte. 
            for (int iByte = 5; iByte >= 1; iByte--)
            {
                int startbit = 7;
                if (iByte == 5)
                { startbit = 6; } //skip the sign bit. 
                //For Each Bit 
                for (int iBit = startbit; iBit >= 0; iBit--)
                {
                    value = value / 2;// Each bit is worth half the next bit but we're going backwards. 
                    if (((real48[iByte] >> iBit) & 1) == 1) //if this bit is set. 
                    {
                        mantissa += value; // add the value. 
                    }
                }
            }
            if (mantissa == 1.0 && real48[0] == 0) // Test for null value 
                return 0.0;
            double result;
            result = (1 + mantissa) * Math.Pow(2.0, exponent);
            if ((real48[5] & 0x80) == 0x80) // Sign bit check 
                result = -result;
            return result;
