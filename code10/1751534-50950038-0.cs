        public static string[] SplitString(string input, int lineLen)
        {
            StringBuilder sb = new StringBuilder();
            string[] words = input.Split(' ');
            string line = string.Empty;
            string sp = string.Empty;
            foreach (string w in words)
            {
                string word = w;
                while (word != string.Empty)
                {
                    if (line == string.Empty)
                    {
                        while (word.Length >= lineLen)
                        {
                            sb.Append(word.Substring(0, lineLen) + "~");
                            word = word.Substring(lineLen);
                        }
                        if (word != string.Empty)
                            line = word;
                        word = string.Empty;
                        sp = " ";
                    }
                    else if (line.Length + word.Length <= lineLen)
                    {
                        line += sp + word;
                        sp = " ";
                        word = string.Empty;
                    }
                    else
                    {
                        sb.Append(line + "~");
                        line = string.Empty;
                        sp = string.Empty;
                    }
                }
            }
            if (line != string.Empty)
                sb.Append(line);
            return sb.ToString().Split('~');
        }
