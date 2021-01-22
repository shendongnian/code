        private static string[] GetWords(string text)
        {
            List<string> lstreturn = new List<string>();
            List<string> lst = text.Split(new[] { ' ' }).ToList();
            foreach (string str in lst)
            {
                if (str.Trim() == "")
                {
                    lstreturn.Add(str);
                }
            }
            return lstreturn.ToArray();
        }
