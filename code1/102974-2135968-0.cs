          //pseudo code
          object ExecuteCodeDynamically(string code)
           {
            Create AppDomain my_app
             src_code = "using System; using System.Reflection; using RemoteLoader;
            namespace MyNameSpace{
           public class MyClass:MarshalByRefObject, IRemoteIterface
          {
          public object Invoke(string local_method, object[] parameters)
            {
           return this.GetType().InvokeMember(local_method, BindingFlags.InvokeMethod, null, this,    parameters);
         }
         public object ExecuteDynamicCode(params object[] parameters)
         {
        " + code + } } } ";// this whole big string is the remote application
    
         //compile this code which is src_code
         //output it as a DLL on the disk rather than in memory with the name e.g.: DynamicHelper.dll. This can be done by playing with the CompileParameters
         // create the factory class in the secondary app-domain
                   RemoteLoader.RemoteLoaderFactory factory =
                      (RemoteLoader.RemoteLoaderFactory)loAppDomain.CreateInstance("RemoteLoader",
                      "RemoteLoader.RemoteLoaderFactory").Unwrap();
    
                // with the help of this factory, we can now create a real instance
                object loObject = factory.CreateInstance("DynamicHelper.dll", "MyNamespace.MyClass", null);
    
                // *** Cast the object to the remote interface to avoid loading type info
                RemoteLoader.IRemoteInterface loRemote = (RemoteLoader.IRemoteInterface)loObject;
    
                if (loObject == null)
                {
                    System.Windows.Forms.MessageBox.Show("Couldn't load class.");
                    return null;
                }
    
                object[] loCodeParms = new object[1];
                loCodeParms[0] = "bla bla bla";
    
                try
                {
                    // *** Indirectly call the remote interface
                    object result = loRemote.Invoke("ExecuteDynamicCode", loCodeParms);// this is the object to return                
    
                }
                catch (Exception loError)
                {
                    System.Windows.Forms.MessageBox.Show(loError.Message, "Compiler Demo",
                        System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Information);
                    return null;
                }
    
                loRemote = null;
                try { AppDomain.Unload(my_app); }
                catch (CannotUnloadAppDomainException ex)
                { String str = ex.Message; }
                loAppDomain = null;
                GC.Collect();//this will do the trick and free the memory
                GC.WaitForPendingFinalizers();
                System.IO.File.Delete("ConductorDynamicHelper.dll");
                return result;
    
    }
