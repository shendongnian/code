       private EventHandler _customEventDelegate;
    
       public event EventHandler MyCustomEvent
       {
          add
          {
              bool wasNull = (_customEventDelegate == null);
              _customEventDelegate += value;
              if(wasNull)
              {
                  this.ChangeButtonVisibility(true);
              }
          }
          remove
          {
              _customEventDelegate -= value;
              if(_customEventDelegate == null)
              {
                 this.ChangeButtonVisibility(false);
              }
          }
       }
   
