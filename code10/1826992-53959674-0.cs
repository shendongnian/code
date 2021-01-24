    public class MyDataGridControl : DataGrid
    {
        public String SomeName
        {
            get { return (String)GetValue(SomeNameProperty); }
            set { SetValue(SomeNameProperty , value); }
        }
        public static readonly DependencyProperty SomeNameProperty = 
            DependencyProperty.Register("SomeName", typeof(String), typeof(MyDataGridControl), new PropertyMetadata(null));
    }
