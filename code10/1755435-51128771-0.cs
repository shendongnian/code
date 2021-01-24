    public class ListViewDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate MaleData { set; get; }
        public DataTemplate FemaleData { set; get; }
    
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (item is Male)
            {
                return MaleData;
            }
            return FemaleData;
        }
    }
