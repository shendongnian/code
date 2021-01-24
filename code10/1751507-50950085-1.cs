    public static void GroupList()
    {
        List<ListComp> lLString = new List<ListComp>();
        string[,] stringArray2D = new string[3, 3] { { "a", "b", "c" },
                                                     { "a", "b", "c" },
                                                     { "d", "e", "f" },
                                                    };
        for (int i = 0; i<stringArray2D.GetLength(0); i++) {
            ListComp temp = new ListComp();
            for (int j = 0; j<stringArray2D.GetLength(1); j++) { 
                temp.Add(stringArray2D[i, j]);
            }
            lLString.Add(temp);
        }
        var gr = lLString.GroupBy(i => i);
        foreach (var g in gr)
        {
            Debug.WriteLine($"{g.Key} = {g.Count()}");
        }
        Debug.WriteLine("");
    }
    public class ListComp : List<string>
    {
        public override string ToString()
        {
            return string.Join(",", this);
        }
        public override bool Equals(object obj)
        {
            ListComp listComp = obj as ListComp;
            if (listComp == null)
                return false;
            else
                return Equals(listComp);
        }
        public bool Equals(ListComp listComp)
        {
            if (listComp == null)
                return false;
            return this.SequenceEqual(listComp);
        }
        public override int GetHashCode()
        {
            int hash = 1;
            foreach(string s in this)
            {
                hash *= s.GetHashCode();
            }
            return hash;
        }
        public ListComp (List<string> listComp)
        {
            this.AddRange(listComp);
        }
        public ListComp()
        {
        }
    }
