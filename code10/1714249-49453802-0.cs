    public class MultiDropDownColumn : Telerik.Windows.Controls.GridViewDataColumn
    {
        public string SelectedItem
        {
            get
            {
                return (string)GetValue(SelectedItemProperty);
            }
            set
            {
                SetValue(SelectedItemProperty, value);
            }
        }
        public override FrameworkElement CreateCellElement(GridViewCell cell, object dataItem)
        {
            TextBlock tb = cell.Content as TextBlock;
            if (tb == null)
            {
                tb = new TextBlock();
            }
            tb.SetBinding(TextBlock.TextProperty, new Binding(SelectedItem));
            return tb;
        }
        public static readonly DependencyProperty SelectedItemProperty =
        DependencyProperty.Register(
            "SelectedItem",
            typeof(string),
            typeof(MultiDropDownColumn),
            new PropertyMetadata(string.Empty, OnSelectedItemChanged));
        private static void OnSelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }
    }
