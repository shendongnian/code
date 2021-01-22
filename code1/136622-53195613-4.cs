    private UpdateManager _updateManager;
    private Person _person = new Person();
    public frmBindingNotification()
    {
        InitializeComponent();
        _updateManager = new UpdateManager(personBindingSource);
        _updateManager.DirtyChanged += UpdateManager_DirtyChanged;
        personBindingSource.DataSource = _person; // Assign the current business object.
    }
    private void UpdateManager_DirtyChanged(object sender, EventArgs e)
    {
        Console.WriteLine(_updateManager.Dirty ? "Dirty" : "Saved"); // Testing only.
    }
