     public class ControlTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;
            if (element != null & item != null && item is ControlModel)
            {
                ControlModel control = item as ControlModel;
                if (control.ControlType.Equals("TextBox"))
                {
                    return element.FindResource("TextBoxDataTemplate") as DataTemplate;
                }
                else
                {
                    return element.FindResource("ComboBoxDatatemplate") as DataTemplate;
                }
            }
            return null;
        }
    }
