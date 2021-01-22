     public string FindBigWords(string s) {
            Regex regEx = new Regex(@"\s+");
            string[] tokens = regEx.Split(s);
            string ret = "";
            foreach (var t in tokens) {
                if (t.Length > 40)
                    ret += t;
            }
            return ret;
     }
