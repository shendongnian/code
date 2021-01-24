    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class XXX
    {
        public int YYY { get; set; }
        public int ZZZ { get; set; }
    
    
        public override string ToString()
        {
            return "X1"; //Or whatever you want shown when the property is collapsed
        }
    }
