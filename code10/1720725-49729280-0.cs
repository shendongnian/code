    public class DataPoint
    {
        [DataMember(Name = "y")]
        public Nullable<double> Y  { get; set; };
        [DataMember(Name = "label")]
        public string Label { get; set; }
        public DataPoint()
        {
        }
        public DataPoint(double y, string label)
        {
           Y = y;
           Label = label;
        }
    }
