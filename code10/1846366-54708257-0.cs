    public class LineItem
    {
        public string Category { get; set; }
        public List<LineItemCheck> LineItemChecks { get; private set; }
        public LineItem()
        {
             LineItemChecks = new List<LineItemCheck>();
        }
    }
    public class RootObject
    {
        public object SerialNumber { get; set; }
        public object UnitNumber { get; set; }
        public object Refrigerant { get; set; }
        public object ModelNumber { get; set; }
        public object BeltSize { get; set; }
        public object FreezingUnitComments { get; set; }
        public object VisualInspectionComments { get; set; }
        public List<LineItem> LineItems { get; private set; }
        public RootObject()
        {
             LineItems = new List<LineItem>();
        }
    }
