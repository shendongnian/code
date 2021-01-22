    class X
    {
       private D __Ev;  // field to hold the delegate
       public event D Ev {
          add {
             lock(this) { __Ev = __Ev + value; }
          }
          remove {
             lock(this) { __Ev = __Ev - value; }
          }
       }
    }
