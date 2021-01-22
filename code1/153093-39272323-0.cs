    public static string ToTitleCase(string strX)
        {
            string[] aryWords = strX.Trim().Split(' ');
            List<string> lstLetters = new List<string>();
            List<string> lstWords = new List<string>();
            foreach (string strWord in aryWords)
            {
                int iLCount = 0;
                foreach (char chrLetter in strWord.Trim())
                {
                    if (iLCount == 0)
                    {
                        lstLetters.Add(chrLetter.ToString().ToUpper());
                    }
                    else
                    {
                        lstLetters.Add(chrLetter.ToString().ToLower());
                    }
                    iLCount++;
                }
                lstWords.Add(string.Join("", lstLetters));
                lstLetters.Clear();
            }
            string strNewString = string.Join(" ", lstWords);
            return strNewString;
        }
