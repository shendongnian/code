        public string RunCharacterCheckASCII(string s)
        {
            string str = s;
            bool is_find = false;
            char ch;
            int ich = 0;
            try
            {
                char[] schar = str.ToCharArray();
                for (int i = 0; i < schar.Length; i++)
                {
                    ch = schar[i];
                    ich = (int)ch;
                    if (ich > 127) // not ascii or extended ascii
                    {
                        is_find = true;
                        schar[i] = '?';
                    }
                }
                if (is_find)
                    str = new string(schar);
            }
            catch (Exception ex)
            {
            }
            return str;
        }
