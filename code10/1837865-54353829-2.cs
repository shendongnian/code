    public class MyStyleSelector : StyleSelector
    {
        public Style DefaultStyle { get; set; }
        public Style CustomStyle { get; set; }
        public override Style SelectStyle(object item, DependencyObject container)
        {
            if (item is LayoutAnchorableItem)
            {
                return CustomStyle;
            }
            return DefaultStyle;
        }
    }
