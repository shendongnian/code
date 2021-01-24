     @functions()
        {
           // private backing field for setting and retrieving the property  value
           bool _value;
          [Parameter]
          protected bool MyValue {
              get{return _value;}
              set {
                _value = value;
                // Call the SideEffect method whenever a new value is assigned to the property. 
                this.SideEffect();
              }
           }
          public void SideEffect()
          {
            Console.WriteLine("has changed"); //i want this method executed when value changes from parent
          }
