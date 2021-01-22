        {
            string Result = string.Empty;
            foreach (char a in key)
            {
                if (Result.Contains(a.ToString().ToUpper()) || Result.Contains(a.ToString().ToLower()))
                    continue;
                Result += a.ToString();
            }
            return Result;
 
        }
