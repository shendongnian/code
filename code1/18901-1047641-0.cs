    public string Name
       {
          get
          {
             return _name;
          }
          set
          {
             ThrowPropertyChangingEvent();
             _name = value;
             ThrowPropertyChangedEvent();
          }
       }
