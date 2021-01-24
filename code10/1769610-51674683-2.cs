     public class MySelector : DataTemplateSelector
    {
    	public override DataTemplate SelectTemplate(object item, DependencyObject container)
    	{
    		FrameworkElement element = container as FrameworkElement;
    
    		if (element != null && item != null && item is YourCustomObject)
    		{
    			YourCustomObject taskitem = item as YourCustomObject;
                
                // HERE i'm putting the custom logic for choosing the correct template
    			if (taskitem.YourProperty == "Value 1")
    				return
    					element.FindResource("firstDataTemplate") as DataTemplate;
    			else
    				return
    					element.FindResource("otherDataTemplate") as DataTemplate;
    		}
    
    		return null;
    	}
    }
