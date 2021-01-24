     public class ControlTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var element = container as FrameworkElement;
            var control = item as ControlModel;
            if (element != null & control != null)
            {
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
