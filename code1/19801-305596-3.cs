    object accessObject = null;
    try
    {
       accessObject = Activator.CreateInstance(Type.GetTypeFromProgID("Access.Application"));
    
       accessObject.GetType().InvokeMember(
          "OpenCurrentDatabase",
          System.Reflection.BindingFlags.Default  System.Reflection.BindingFlags.InvokeMethod,
          null,
          accessObject,
          new Object[] { "AccessDbase.mdb" });
    
       accessObject.GetType().InvokeMember(
          "Run",
          System.Reflection.BindingFlags.Default  System.Reflection.BindingFlags.InvokeMethod,
          null,
          accessObject,
          new Object[] { "Import", "DSN Name", "Source table name", "Target table name" });
    
       accessObject.GetType().InvokeMember(
          "CloseCurrentDatabase",
          System.Reflection.BindingFlags.Default  System.Reflection.BindingFlags.InvokeMethod,
          null,
          accessObject,
          null);
    
       MessageBox.Show("Copy succeeded.");
    }
    catch (Exception ex)
    {
       string message = ex.Message;
       while (ex.InnerException != null)
       {
          ex = ex.InnerException;
          message += "\r\n----\r\n" + ex.Message;
       }
       MessageBox.Show(message);
    }
    finally
    {
       if (accessObject != null)
       {
          System.Runtime.InteropServices.Marshal.ReleaseComObject(accessObject);
          accessObject = null;
       }
    }
