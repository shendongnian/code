    static class FilterTypes
    {
        public const string Rigid = "Rigid";
        // ...
    }
    // or ...
    class FilterType
    {
        static readonly RigidFilterType = new FilterType("Rigid");
        string name;
 
        FilterType(string name)  // private constructor
        {
            this.name = name;
        }
        public static FilterType Rigid
        {
            get { return FilterType.RigidFilterType; }
        }
        // ...
    }
