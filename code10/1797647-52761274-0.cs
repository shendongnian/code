    public static List<int> GetNewLineLocations(this string[] lines)
            {
                var list = new List<int>();
                int ix = -1;
    
                for (int i = 0; i < lines.Length; i++)
                {
                    ix += lines[i].Length+1;
                    list.Add(ix);
                }
    
                return list;
            }
