    public static class ControlExtension
    {
       public static void ThreadSafeInvoke(this Control control, MethodInvoker method)
       {
          if (control != null)
          {
             if (control.InvokeRequired)
             {
                control.Invoke(method);
             }
             else
             {
                method.Invoke();
             }
          }
       }
    }
