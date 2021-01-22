    static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) {
      var ex = e.ExceptionObject as Exception;
      MessageBox.Show(ex.ToString());
      if (!System.Diagnostics.Debugger.IsAttached)
        Environment.Exit(System.Runtime.InteropServices.Marshal.GetHRForException(ex));
    }
