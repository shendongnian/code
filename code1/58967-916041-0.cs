    public class MyUserControl : UserControl
    {
        public MyUserControl()
        {
            Resources["MyDataTemplateSelector"] = new MyDataTemplateSelector(this);
            InitializeComponent();
        }
    }
    
    public class MyDataTemplateSelector : DataTemplateSelector
    {
        private MyUserControl parent;
        public MyDataTemplateSelector(MyUserControl parent)
        {
            this.parent = parent;
        }
        
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            parent.DoStuff();
        }
    }
