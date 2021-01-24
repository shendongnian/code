    public partial class Shape1 : IShape 
    {
        public IColor BaseContent
        {
            get { return Content; }
            set { Content = (Color1) value; }
        }
    }
    
    public partial class Shape2 : IShape 
    {
        public IColor BaseContent
        {
            get { return Content; }
            set { Content = (Color2) value; }
        }
    }
