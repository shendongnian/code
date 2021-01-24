    public class DataTemplateSelectorExt : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item == null) return (DataTemplate)null;
            FrameworkElement frameworkElement = container as FrameworkElement;
            if (item.Equals("Please reach out here. No access can be provided."))
                return Application.Current.MainWindow.FindResource("NoAccess") as DataTemplate;
            
                return null;
        }
    }
