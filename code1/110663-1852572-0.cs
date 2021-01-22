        public static string ToAlpha(int index)
        {
            if (index <= 0)
            {
                throw new ArgumentOutOfRangeException("index");
            }
            --index;
            var chars = new List<char>();
            int x = index;
            do
            {
                int r = x % 26;
                chars.Insert(0, Convert.ToChar(65 + r));
                x /= 26;
            } while (x > 26);
            if (x > 0)
            {
                chars.Insert(0, Convert.ToChar(64 + x));
            }
            return new string(chars.ToArray());
        }
        public static int ToNumeric(string index)
        {
            int total = 0;
            var chars = index.ToCharArray();
            int chrIndex = chars.Length - 1;
            foreach (char chr in chars)
            {
                total += (Convert.ToInt32(chr) - 64) * (int)(Math.Pow(26d, (double)chrIndex));
                --chrIndex;
            }
            return total;
        }
