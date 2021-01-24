    <!-- 
    [FileNotFoundException]: Could not find file &#39;D:\INETPUB\VHOSTS\xinksoft.com\ssdm.xinksoft.com\bin\roslyn\csc.exe&#39;.
       at System.IO.__Error.WinIOError(Int32 errorCode, String maybeFullPath)
       at System.IO.FileStream.Init(String path, FileMode mode, FileAccess access, Int32 rights, Boolean useRights, FileShare share, Int32 bufferSize, FileOptions options, SECURITY_ATTRIBUTES secAttrs, String msgPath, Boolean bFromProxy, Boolean useLongPath, Boolean checkHost)
       at System.IO.FileStream..ctor(String path, FileMode mode, FileAccess access, FileShare share)
       at Microsoft.CodeDom.Providers.DotNetCompilerPlatform.Compiler.get_CompilerName()
       at Microsoft.CodeDom.Providers.DotNetCompilerPlatform.Compiler.FromFileBatch(CompilerParameters options, String[] fileNames)
       at Microsoft.CodeDom.Providers.DotNetCompilerPlatform.Compiler.CompileAssemblyFromFileBatch(CompilerParameters options, String[] fileNames)
       at System.CodeDom.Compiler.CodeDomProvider.CompileAssemblyFromFile(CompilerParameters options, String[] fileNames)
       at System.Web.Compilation.AssemblyBuilder.Compile()
       at System.Web.Compilation.BuildProvidersCompiler.PerformBuild()
       at System.Web.Compilation.BuildManager.CompileWebFile(VirtualPath virtualPath)
       at System.Web.Compilation.BuildManager.GetVPathBuildResultInternal(VirtualPath virtualPath, Boolean noBuild, Boolean allowCrossApp, Boolean allowBuildInPrecompile, Boolean throwIfNotFound, Boolean ensureIsUpToDate)
       at System.Web.Compilation.BuildManager.GetVPathBuildResultWithNoAssert(HttpContext context, VirtualPath virtualPath, Boolean noBuild, Boolean allowCrossApp, Boolean allowBuildInPrecompile, Boolean throwIfNotFound, Boolean ensureIsUpToDate)
       at System.Web.Compilation.BuildManager.GetVirtualPathObjectFactory(VirtualPath virtualPath, HttpContext context, Boolean allowCrossApp, Boolean throwIfNotFound)
       at System.Web.Compilation.BuildManager.CreateInstanceFromVirtualPath(VirtualPath virtualPath, Type requiredBaseType, HttpContext context, Boolean allowCrossApp)
       at System.Web.UI.PageHandlerFactory.GetHandlerHelper(HttpContext context, String requestType, VirtualPath virtualPath, String physicalPath)
       at System.Web.UI.PageHandlerFactory.GetHandler(HttpContext context, String requestType, String virtualPath, String path)
       at System.Web.HttpApplication.MaterializeHandlerExecutionStep.System.Web.HttpApplication.IExecutionStep.Execute()
    [HttpException]: Exception of type &#39;System.Web.HttpException&#39; was thrown.
       at System.Web.HttpApplication.MaterializeHandlerExecutionStep.System.Web.HttpApplication.IExecutionStep.Execute()
       at System.Web.HttpApplication.ExecuteStepImpl(IExecutionStep step)
       at System.Web.HttpApplication.ExecuteStep(IExecutionStep step, Boolean& completedSynchronously)
    -->
