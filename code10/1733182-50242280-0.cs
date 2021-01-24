     public class MyStringComparer : Comparer<string>, IComparer<string>
        {
            public override int Compare(string x, string y)
            {
                decimal dx = Convert.ToDecimal(Regex.Replace(x, @"[^\d]", ""));
                decimal dy = Convert.ToDecimal(Regex.Replace(y, @"[^\d]", ""));
                return Convert.ToInt32(dx - dy);
            }
        }
