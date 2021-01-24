    public partial class Shape1 : IShape 
    {
        IColor IShape.Content 
        {
            get { return ((Shape1)this).Content; }
            set { ((Shape1)this).Content = (Color1) value; }
        }
    }
    
    public partial class Shape2 : IShape 
    {
        IColor IShape.Content 
        {
            get { return ((Shape2)this).Content; }
            set { ((Shape2)this).Content = (Color2) value; }
        }
    }
