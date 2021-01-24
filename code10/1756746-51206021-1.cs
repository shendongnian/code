    public class Selector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            Person person = item as Person;
            if(person != null && person.Cars != null)
            {
                DataTemplate cardLayout = new DataTemplate();
                foreach (Car car in person.Cars)
                {
                    //build your template..
                }
                return cardLayout;
            }
            return null;
        }
    }
