    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class X
    {
        private Control owner;
        internal X(Control owner)
        {
            this.owner = owner;
        }
        public int XXX { get; set; }
        public int YYY { get; set; }
    }
