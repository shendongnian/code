    public class DataTableIgnoreCaseComparer : IEqualityComparer<string>
    {
        private readonly System.Globalization.CompareInfo ci =
            System.Globalization.CultureInfo.CurrentCulture.CompareInfo; 
        private const System.Globalization.CompareOptions options = 
            CompareOptions.IgnoreCase | 
            CompareOptions.IgnoreKanaType | 
            CompareOptions.IgnoreWidth;
    
        public DataTableIgnoreCaseComparer() {}
	
        public bool Equals(string a, string b)
        {
            return ci.Compare(a, b, options) == 0;
        }
	
        public int GetHashCode(string s)
        {
            return ci.GetSortKey(s, options).GetHashCode();
        }
    }
