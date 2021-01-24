    public class NaturalSortComparer : IComparer<string>
    {
        Regex _Regex = new Regex(@"(\d+)|(\D+)");
        public int Compare(string s1, string s2)
        {
            var list1 = _Regex.Matches(s1).Cast<Match>().Select(m => m.Value.Trim()).ToList();
            var list2 = _Regex.Matches(s2).Cast<Match>().Select(m => m.Value.Trim()).ToList();
            var min = Math.Min(list1.Count, list2.Count);
            int comp = 0;
            for (int i = 0; i < min; i++)
            {
                int intx, inty;
                if (int.TryParse(list1[i], out intx) && int.TryParse(list2[i], out inty))
                    comp = intx - inty;
                else
                    comp = String.Compare(list1[i], list2[i]);
                if (comp != 0) return comp;
            }
            return list1.Count - list2.Count;
        }
    }
