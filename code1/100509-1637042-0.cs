            string str =  "(USD 92.90)";
            decimal result;
            if (Decimal.TryParse(str, out result))
            {
                // the parse worked
            }
            else
            {
                // Invalid string
            }
