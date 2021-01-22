    // the interface, inherit from IComparable
    public interface IX : IComparable<IX>
    {
        string T1 { get; set; }
    }
    
    // create one base class
    class XBase : IX
    {
        public string T1 { get; set; }
        public int CompareTo(IX obj)
        {
            return this.T1.equals(obj.T1);
        }
    }
    
    // inherit all others from base class
    class X : XBase
    {
        public string T2 { get; set; }
        public string T3 { get; set; }
    }
    
    class Y : XBase
    {
        public string T2 { get; set; }
        public string T3 { get; set; }
    
        public strign O1 { get; set; }
    }
