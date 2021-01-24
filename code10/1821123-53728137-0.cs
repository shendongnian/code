        private static string ConvertToOtherBase(string toConvert, int fromBase, int toBase)
        {
            const string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                        
            long value = 0;
            string result = "";
            foreach (char digit in toConvert.ToCharArray())
                value = (value * fromBase) + characters.IndexOf(digit);
            while (value > 0)
            {
                result = characters[(int)(value % toBase)] + result;
                value /= toBase;
            }
            return result;
        }
