solutionEventsSink = new SolutionEventsSink(orderController);
System.IServiceProvider serviceProvider = new Microsoft.VisualStudio.Shell.ServiceProvider(
dte as Microsoft.VisualStudio.OLE.Interop.IServiceProvider);
vsSolution = serviceProvider.GetService(typeof(Microsoft.VisualStudio.Shell.Interop.SVsSolution)) as
Microsoft.VisualStudio.Shell.Interop.IVsSolution;
vsSolution.AdviseSolutionEvents(solutionEventsSink, out sinkCookie);
