        private string GetProperName(string Header)
        {
            if (Header.ToCharArray().Where(c => Char.IsUpper(c)).Count() == 1)
            {
                return Header;
            }
            else
            {
                string ReturnHeader = Header[0].ToString();
                for(int i=1; i<Header.Length;i++)
                {
                    if (char.IsLower(Header[i-1]) && char.IsUpper(Header[i]))
                    {
                        ReturnHeader += " " + Header[i].ToString();
                    }
                    else
                    {
                        ReturnHeader += Header[i].ToString();
                    }
                }
                return ReturnHeader;
            }
            return Header;
        }
