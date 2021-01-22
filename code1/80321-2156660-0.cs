        public static string NormalizeWhiteSpace(string S)
        {
            string s = S.Trim();
            bool iswhite = false;
            int iwhite;
            int sLength = s.Length;
            StringBuilder sb = new StringBuilder(sLength);
            foreach(char c in s.ToCharArray())
            {
                if(Char.IsWhiteSpace(c))
                {
                    if (iswhite)
                    {
                        //Continuing whitespace ignore it.
                        continue;
                    }
                    else
                    {
                        //New WhiteSpace
                       
                        //Replace whitespace with a single space.
                        sb.Append(" ");
                        //Set iswhite to True and any following whitespace will be ignored
                        iswhite = true;
                    }  
                }
                else
                {
                    sb.Append(c.ToString());
                    //reset iswhitespace to false
                    iswhite = false;
                }
            }
            return sb.ToString();
        }
