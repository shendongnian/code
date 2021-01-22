      private EventHandler _h;
      public event EventHandler H {
          add {
             if (...) { // Your conditions here.
                        // Warning (as per comments): clients may not
                        // expect problems to occur when adding listeners!
               _h += value;
             }
          }
          remove {
             _h -= value;
          }
      }
