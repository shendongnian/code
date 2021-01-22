    public class CustControl : Control 
        {
          static CustControl()
           {
             DefaultStyleKeyProperty.OverrideMetadata(typeof(CustControl), new FrameworkPropertyMetadata(typeof(CustControl)));       
           }        
        public readonly static DependencyProperty MyFirstProperty = DependencyProperty.Register("MyFirst", typeof(string), typeof(CustControl), new PropertyMetadata(""));
        public string MyFirst
        {
            get { return (string)GetValue(MyFirstProperty); }
            set { SetValue(MyFirstProperty, value); }
        }
    }
