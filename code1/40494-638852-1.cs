    public static object SmartInvoke(this Control control, MethodInvoker del) {
      if ( control.InvokeRequired ) {
        control.Invoke(del);
        return;
      }
      del();
    }
