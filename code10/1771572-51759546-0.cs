    Sub Run(DTE As DTE2, package As Package)
    	Dim cmd As EnvDTE.Command
    	Dim shell As Microsoft.VisualStudio.Shell.Interop.IVsUIShell
    	Dim arg As Object
    	Dim guid As System.Guid
    	Dim serviceProvider As System.IServiceProvider
    	serviceProvider = New Microsoft.VisualStudio.Shell.ServiceProvider(
    	           CType(DTE, Microsoft.VisualStudio.OLE.Interop.IServiceProvider))
    	shell = serviceProvider.GetService(GetType(Microsoft.VisualStudio.Shell.Interop.SVsUIShell))
    	cmd = DTE.Commands.Item("Build.BuildSolution", 0)
    	guid = New System.Guid(cmd.Guid)
    	shell.PostExecCommand(guid, cmd.ID, 0, arg)
    End Sub
