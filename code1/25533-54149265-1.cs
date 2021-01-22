        public int[] ToASCII(string s)
        {
            char c;
            int[] cByte = new int[s.Length];   / the ASCII string
            for (int i = 0; i < s.Length; i++)
            {
                c = s[i];                        // get a character from the string s
                cByte[i] = Convert.ToInt16(c);   // and convert it to ASCII
            }
            return cByte;
        }
