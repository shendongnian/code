     public class TaskListDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item != null && item is Task)
            {
                var taskitem = (Task)item;
                var window = Application.Current.MainWindow;
                if (taskitem.Priority == 1)
                    return ((FrameworkElement)container).FindResource
                        ("ImportantTaskTemplate") as DataTemplate;
          
                return
                ((FrameworkElement)container).FindResource
                        ("MyTaskTemplate") as DataTemplate;
            }
            return null;
        }
    }
