        public static unsafe int ParseBasicInt32(string s)
        {
            int len = s == null ? 0 : s.Length;
            switch(s.Length)
            {
                case 0:
                    throw new ArgumentException("s");
                case 1:
                    {
                        char c0 = s[0];
                        if (c0 < '0' || c0 > '9') throw new ArgumentException("s");
                        return c0 - '0';
                    }
                case 2:
                    {
                        char c0 = s[0], c1 = s[1];
                        if (c0 < '0' || c0 > '9' || c1 < '0' || c1 > '9') throw new ArgumentException("s");
                        return ((c0 - '0') * 10) + (c1 - '0');
                    }
                default:
                    fixed(char* chars = s)
                    {
                        int value = 0;
                        for(int i = 0; i < len ; i++)
                        {
                            char c = chars[i];
                            if (c < '0' || c > '9') throw new ArgumentException("s");
                            value = (value * 10) + (c - '0');
                        }
                        return value;
                    }
            }
        }
