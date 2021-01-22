        public static List<string> _Split(this string input,string[] splt)
        {
            List<string> _Result=new List<string>();
            foreach(string _splt in splt)
            {
                if (splt.Count() == 1)
                { 
                    _Result.AddRange(Regex.Split(input, _splt, RegexOptions.IgnoreCase).ToList());
                }
                else 
                {
                    List<string> NewStr = Regex.Split(input, _splt, RegexOptions.IgnoreCase).ToList();
                    foreach(string _NewStr in NewStr)
                    {
                        List<string> NewSplt = splt.ToList();
                        NewSplt.Remove(_splt);
                        return _Split(_NewStr, NewSplt.ToArray());
                    }
                } 
            }
            return _Result;
        } 
 
