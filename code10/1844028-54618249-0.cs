    public class CityInfoComparer:IComparer<CityInfo>
    {
        private readonly IComparer<string> _baseComparer;
    
        public CityInfoComparer(IComparer<string> baseComparer)
        {
            _baseComparer = baseComparer;
        }
    
        public int Compare(CityInfo city1, CityInfo city2)
        {
            return _baseComparer.Compare(city1.CityName, city2.CityName);
        }
    }
    
    
    public class CityList
    {
        public List<CityInfo> CityInfos { get; set; }
    
        public void Sort()
        {
            CityInfos.Sort( new CityInfoComparer(StringComparer.CurrentCulture));
        }
    
    }
