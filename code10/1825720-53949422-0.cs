    public class SampleDataTemplateSelector : DataTemplateSelector
    {
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (item != null && container != null && <<item is a specific object>>)
            {
                // Put your logic code here in order to determine what case is the right one
                if (<<case 1>>) return SampleDataTemplate1;
                else if (<<case 2>>) return SampleDataTemplate2;
                //…
            }
        }
    }
