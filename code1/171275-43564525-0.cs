      private string FixString(string str)
        {
            string outStr = "";
            if (!string.IsNullOrEmpty(str))
            {
                Regex rgx = new Regex("[\\D]");
                outStr = rgx.Replace(str, "");
            }
            return outStr ;
        }
