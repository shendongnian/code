    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class X
    {
        public int XXX { get; set; }
        public int YYY { get; set; }
     
        public override string ToString()
        {
            return "X1"; //Or whatever you want shown when the property is collapsed
        }
    }
