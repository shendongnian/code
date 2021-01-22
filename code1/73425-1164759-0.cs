    public class BindableGridColumn : DataGridTextColumn
        {
            public DataGridLength BindableWidth
            {
                get { return Width; }
                set { Width = value; }
            }
    
            // Using a DependencyProperty as the backing store for BindableWidth.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty BindableWidthProperty =
                DependencyProperty.Register("BindableWidth", typeof(DataGridLength), typeof(BindableGridColumn), new PropertyMetadata(DataGridLength.Auto));
        }
