    class YourClass
    {
        //Property to Bind
        public Func<ChartPoint,string> ABLabelPoint { get; set; }
        //Constructor
        public YourClass()
        {
            //Define LabelPoint, where 0 = A, 1 = B etc.
            //Or use your Code, doesent really matter
            ABLabelPoint = point => ((char)(point.X + 65)).ToString();
        }
    }
