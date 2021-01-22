    var hostServiceProvider = (IServiceProvider)Host;
    var dte = (EnvDTE.DTE)hostServiceProvider.GetService(typeof(EnvDTE.DTE));
    var activeSolutionProjects = (Array)dte.ActiveSolutionProjects;
    var dteProject = (EnvDTE.Project)activeSolutionProjects.GetValue(0);
    var defaultNamespace = dteProject.Properties.Item("DefaultNamespace").Value;
