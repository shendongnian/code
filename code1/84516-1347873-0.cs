    public class DependencyPropertyTest : DependencyObject
    {
      public static readonly DependencyProperty FirstProperty;
      public static readonly DependencyProperty SecondProperty;
            
      static DependencyPropertyTest()
      {
        FirstProperty  = DependencyProperty.Register("FirstProperty", 
                                                      typeof(bool), 
                                                      typeof(DependencyPropertyTest), 
                                                      new PropertyMetadata(false, FirstPropertyChanged));
              
        SecondProperty = DependencyProperty.Register("SecondProperty", 
                                                     typeof(string), 
                                                     typeof(DependencyPropertyTest), 
                                                     new PropertyMetadata(null));
      } // End constructor
            
      private bool First
      {
        get { return (bool)this.GetValue(FirstProperty); }
        set { this.SetValue(FirstProperty, value);       }
    
      } // End property First
            
      private string Second
      {
        get { return (string)this.GetValue(SecondProperty); }
        set { this.SetValue(SecondProperty, value);         }
    
      } // End property Second
            
      private static void FirstPropertyChanged(DependencyObject dependencyObject, 
                                               DependencyPropertyChangedEventArgs ea)
      {
        DependencyPropertyTest instance = dependencyObject as DependencyPropertyTest;
              
        if (instance == null)
        {
          return;
        }
              
        instance.Second = String.Format("First is {0}.", ((bool)ea.NewValue).ToString());
        
      } // End method FirstPropertyChanged
    } // End class DependencyPropertyTest
  
