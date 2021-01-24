    public class MyDataTemplateSelector : DataTemplateSelector
        {
            public DataTemplate DataTemplate1 { get; set; }
    
            public DataTemplate DataTemplate2 { get; set; }
    
            protected override DataTemplate SelectTemplateCore(object item)
            {
                if ([Condition 1] == true)
                    return DataTemplate1;
    
                if ([Condition 2] == true)
                    return DataTemplate2;
    
                return base.SelectTemplateCore(item);
            }
    
            protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
            {
                return SelectTemplateCore(item);
            }
        }
