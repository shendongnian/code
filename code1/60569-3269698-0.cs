       public override object ProvideValue(IServiceProvider serviceProvider){                                
                    var pvt = serviceProvider as IProvideValueTarget;
                    if (pvt == null)
                    {
                        return null;
                    }
        
        
                    var frameworkElement = pvt.TargetObject as FrameworkElement;
                    if (frameworkElement == null)
                    {
                        return this;
                    }
    //.... Code will run once the markup is correctly loaded
     var dataContext = frameworkElement.DataContext; 
    
    
        }
