    public class CustomStyleSelector: StyleSelector
    {
        public Style style1 { get; set; }
        public Style style2 { get; set; }
        public Style style3 { get; set; }
        protected override Style SelectStyleCore(object item, DependencyObject container)
        {
            if (item is NavigationViewItem)
            {
                if ((item as NavigationViewItem).Content.ToString() == "item1")
                {
                    return style1;
                }
                if ((item as NavigationViewItem).Content.ToString() == "item2")
                {
                    return style2;
                }
                if ((item as NavigationViewItem).Content.ToString() == "item3")
                {
                    return style3;
                }
            }
            return base.SelectStyleCore(item, container);
        }
    }
