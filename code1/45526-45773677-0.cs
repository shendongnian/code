    public class EmptyDefaultDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item != null)
            {
                var dataTemplateKey = new DataTemplateKey(item.GetType());
                var dataTemplate = ((FrameworkElement) container).TryFindResource(dataTemplateKey);
                if (dataTemplate != null)
                    return (DataTemplate) dataTemplate;
            }
            return new DataTemplate(); //null does not work
        }
    }
