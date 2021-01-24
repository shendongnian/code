    public class UserControlDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (container is FrameworkElement fe)
            {
                if (item is MyComboBoxItem cbItem)
                {
                    if (cbItem.Color == "Red")
                    {
                        return fe.FindResource("RedUserControlDataTemplate") as DataTemplate;
                    }
                    if (cbItem.Color == "Green")
                    {
                        return fe.FindResource("GreenUserControlDataTemplate") as DataTemplate;
                    }
                    return fe.FindResource("UnspecifiedUserControlDataTemplate") as DataTemplate;
                }
            }
            return null;
        }
    }
