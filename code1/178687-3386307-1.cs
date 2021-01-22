    private DelegateCommand exitCommand;
    private DelegateCommand reloadCommand;
    public ICommand ExitCommand { get { return exitCommand ?? (exitCommand = new DelegateCommand(Exit)); } }
    public ICommand ReloadCommand { get { return reloadCommand ?? (reloadCommand = new DelegateCommand(Reload)); } }
    private static void Exit() { Application.Current.Shutdown(); }
    private void Reload() { LoadData(); }
