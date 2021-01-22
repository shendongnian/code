    public static object SmartInvoke(this Control control, MethodInvoker del) {
      if ( control.InvokeRequired ) {
        return control.Invoke(del);
      }
      return del();
    }
