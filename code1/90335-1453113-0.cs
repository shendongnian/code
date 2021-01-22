    public static DependencyProperty AnimateValueProperty = 
       DependencyProperty.Register(
          "AnimateValue",
          typeof(double),
          typeof(MyClass)
       );
     // This is for the Readonly GuiValueKey property
     public static DependencyPropertyKey GuiValueKey = 
         DependencyProperty.RegisterReadOnly (
         "GuiValue",
          typeof(double),
          typeof(MyClass),
          new UIPropertyMetadata(0.0)
    );
    public double AnimateValue {
        get { return (double)GetValue(AnimateValueProperty); }
        set {
                SetValue(AnimateValueProperty, value);
                // Following statement update GuiValue wherever it
                // is binded
                this.SetValue(GuiValueKey,value + 10);
            }
        }
    }
    // you dont even need following line...
    // but its good to have it..
    public double GuiValue {
        get { 
            return (double)this.GetValue(GuiValueKey); 
        }
    }
