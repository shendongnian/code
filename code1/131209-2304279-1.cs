    ViewModelBuilderFactory factory = new ViewModelBuilderFactory();
    IViewModelBuilder modelBuilder = factory.GetViewModelBuilder(repository);
    this.DocTreeViewModel = modelBuilder.GetDocTreeViewModel;
    Workspace workspace = modelBuilder.GetWorkspace(patient);
    this.Workspaces.Add(workspace);
    this.SetActiveWorkspace(worspace);
