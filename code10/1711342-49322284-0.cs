            string str = "Psppsp palm springs airport, 3400 e tahquitz canyon way, Palm springs, CA, US, 92262-6966 psppsp";
            string word = "psppsp";
            // Check if str and word are equals
            if (str == word)
            {
                str = "";
            }
            // Check Firt word in str
            if (str.Length > word.Length)
            {
                bool equal = true;
                for (int i = 0; i < word.Length; i++)
                {
                    if (str[i] != word[i])
                    {
                        equal = false;
                        break;
                    }
                }
                if (equal && str[word.Length] == ' ')
                {
                    str = str.Substring(word.Length);
                }
            }
            // Check Last word in str
            if (str.Length > word.Length)
            {
                bool equal = true;
                for (int i = word.Length - 1; i >= 0; i--)
                {
                    if (str[str.Length - word.Length + i] != word[i])
                    {
                        equal = false;
                        break;
                    }
                }
                if (equal)
                {
                    str = str.Substring(0, str.Length - word.Length);
                }
            }
