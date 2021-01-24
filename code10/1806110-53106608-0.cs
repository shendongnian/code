    private void Execute(object sender, EventArgs e)
    {
        ThreadHelper.ThrowIfNotOnUIThread();
        _SelectedObject = this.GetProjectItem();
        _VsProject = _SelectedObject.ContainingProject;
        this.BuildProject(_VsProject);
    }
    private void BuildProject(EnvDTE.Project vsProject)
    {
        DTE2 dte = Package.GetGlobalService(typeof(EnvDTE.DTE)) as DTE2;
        dte.Events.BuildEvents.OnBuildDone -= BuildEvents_OnBuildDone;
        dte.Events.BuildEvents.OnBuildDone += BuildEvents_OnBuildDone;
        dte.ExecuteCommand("Build.RebuildSolution");
    }
    private void BuildEvents_OnBuildDone(vsBuildScope Scope, vsBuildAction Action)
    {
        //Your action after build here
    }
