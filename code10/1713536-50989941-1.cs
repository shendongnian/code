    public class CommandBarMenuItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate CbMenuItemTemplate { get; set; }
 
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (item is ContextAction)
            {
                return CbMenuItemTemplate;
            }
            return base.SelectTemplateCore(item, container);
        }
    }
