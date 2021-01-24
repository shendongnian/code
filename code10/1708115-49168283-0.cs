    public static List<String> CustomSort(List<String> ls)
        {
            
            ls.Sort();
            List<String> Oint = new List<String>();
            List<String> Ocap = new List<String>();
            List<String> Osma = new List<String>();
            
            foreach(string s in ls)
            {
                int n;
                bool isNumeric = int.TryParse(s, out n);
                if(isNumeric)
                {
                    Oint.Add(s);
                }
                else if (char.IsUpper(s[0]))
                {
                    Ocap.Add(s);
                }
                else if (!char.IsUpper(s[0]))
                {
                    Osma.Add(s);
                }
            }
            
            var r1 = Oint.Concat(Osma).Concat(Ocap);
            
            List<String> com = r1.ToList();
            return com;
            
        }
