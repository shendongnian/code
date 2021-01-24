        public Boolean ValidateGTIN(string gtin)
        {
            string tmpGTIN = gtin;
            if (tmpGTIN.Length < 13)
            {
                Console.Write("GTIN code is invalid (should be at least 13 digits long)");
                return false;
            }
            else if (tmpGTIN.Length == 13)
            {
                tmpGTIN = "0" + gtin;
            }
            // Now that you have a GTIN with 14 digits, you can check the checksum
            Boolean IsValid = false;
            int Sum = 0;
            int EvenSum = 0;
            int CurrentDigit = 0;
            for (int pos = 0; pos <= 12; ++pos)
            {                
                Int32.TryParse(tmpGTIN[pos].ToString(), out CurrentDigit);
                if (pos % 2 == 0)
                {                    
                    EvenSum += CurrentDigit;
                }                    
                else
                {
                    Sum += CurrentDigit;
                }                    
            }
            Sum += 3 * EvenSum;
            Int32.TryParse(tmpGTIN[13].ToString(), out CurrentDigit);
            IsValid = ((10 - (Sum % 10)) % 10) == CurrentDigit;
            if (!IsValid)
            {
                Console.Write("GTIN code is invalid (wrong checksum)");
            }
            return IsValid;
        }
