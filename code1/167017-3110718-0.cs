     public static class UIThreadSafe {
            
         public static void Perform(Control c, MethodInvoker inv) {
                if(c == null)
                    return;
                if(c.InvokeRequired) {
                    c.Invoke(inv, null);
                }
                else {
                    inv();
                }
          }
      }
