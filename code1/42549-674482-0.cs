        public static void smartSplit(string text, char delim, char esc, ref List<string> listToBuild)
        {
            bool currentlyEscaped = false;
            StringBuilder fragment = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                if (currentlyEscaped)
                {
                    fragment.Append(c);
                    currentlyEscaped = false;
                }
                else 
                {
                    if (c == delim)
                    {
                        if (fragment.Length > 0)
                        {
                            listToBuild.Add(fragment.ToString());
                            fragment.Remove(0, fragment.Length);
                        }
                        
                    }
                    else if (c == esc)
                        currentlyEscaped = true;
                    else
                        fragment.Append(c);
                }
            }
            if (fragment.Length > 0)
            {
                listToBuild.Add(fragment.ToString());
            }
        }
