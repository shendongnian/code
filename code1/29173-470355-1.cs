    Could not load file or assembly 'PrintTest2007, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null' or one of its dependencies. Failed to grant permission to execute. (Exception from HRESULT: 0x80131418)
    
    
    ************** Exception Text **************
    System.IO.FileLoadException: Could not load file or assembly 'PrintTest2007, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null' or one of its dependencies. Failed to grant permission to execute. (Exception from HRESULT: 0x80131418)
    File name: 'PrintTest2007, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null' ---> System.Security.Policy.PolicyException: Execution permission cannot be acquired.
       at System.Security.SecurityManager.ResolvePolicy(Evidence evidence, PermissionSet reqdPset, PermissionSet optPset, PermissionSet denyPset, PermissionSet& denied, Boolean checkExecutionPermission)
       at System.Security.SecurityManager.ResolvePolicy(Evidence evidence, PermissionSet reqdPset, PermissionSet optPset, PermissionSet denyPset, PermissionSet& denied, Int32& securitySpecialFlags, Boolean checkExecutionPermission)
       at Microsoft.VisualStudio.Tools.Applications.Runtime.AppDomainManagerInternal.HandleOnlineOffline(Exception e, String basePath, String filePath)
       at Microsoft.VisualStudio.Tools.Applications.Runtime.AppDomainManagerInternal.LoadStartupAssembly(EntryPoint entryPoint, Dependency dependency, Dictionary`2 assembliesHash)
       at Microsoft.VisualStudio.Tools.Applications.Runtime.AppDomainManagerInternal.ConfigureAppDomain()
       at Microsoft.VisualStudio.Tools.Applications.Runtime.AppDomainManagerInternal.LoadAssembliesAndConfigureAppDomain(IHostServiceProvider serviceProvider)
       at Microsoft.VisualStudio.Tools.Applications.Runtime.AppDomainManagerInternal.LoadEntryPointsHelper(IHostServiceProvider serviceProvider)
