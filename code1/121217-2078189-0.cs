      private EventHandler _h;
      public event EventHandler H {
          add {
             if (...) { // Your conditions here.
               _h += value;
             }
          }
          remove {
             _h -= value;
          }
      }
