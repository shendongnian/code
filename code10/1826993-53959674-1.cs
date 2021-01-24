    public class MyDataGridControl : DataGrid
    {
        public string SomeName
        {
            get { return (string)GetValue(SomeNameProperty); }
            set { SetValue(SomeNameProperty, value); }
        }
        public static readonly DependencyProperty SomeNameProperty = 
            DependencyProperty.Register(
                nameof(SomeName), typeof(string), typeof(MyDataGridControl),
                new PropertyMetadata(null));
    }
