    static void Main(String[] argv)
      {
         // Create a new AppDomain, but with the base directory set to either the 32-bit or 64-bit
         // sub-directories.
         
         AppDomainSetup objADS = new AppDomainSetup();
         System.String assemblyDir = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
         switch (System.IntPtr.Size)
         {
            case (4): assemblyDir += "\\win32\\";
               break;
            case (8): assemblyDir += "\\x64\\";
               break;
         }
         objADS.ApplicationBase = assemblyDir;
         
         // We set the PrivateBinPath to the application directory, so that we can still
         // load the platform neutral assemblies from the app directory.
         objADS.PrivateBinPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
         AppDomain objAD = AppDomain.CreateDomain("", null, objADS);
         if (argv.Length > 0)
            objAD.ExecuteAssembly(argv[0]);
         else
            objAD.ExecuteAssembly("MyApplication.exe");
         AppDomain.Unload(objAD);
      }
