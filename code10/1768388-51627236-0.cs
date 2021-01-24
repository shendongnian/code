    public class YourTemplateSelector : DataTemplateSelector
    {
      public DataTemplate ComboTemplate
      { get; set; }
    	
      public DataTemplate TextTemplate
      { get; set; }
    
      public DataTemplate CheckTemplate
      { get; set; }
    	
      public override DataTemplate SelectTemplate(object item, DependencyObject container)
      {
        MyObject obj = item as MyObject;
    
        if (obj != null)
        {
    			// Select your template
        }
        else
          return base.SelectTemplate(item, container);
      }
    }
