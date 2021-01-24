    private ProjectEntities _context;
    public MainForm()
    {
        InitializeComponent();
    }
    private async void MainForm_Loaded(object sender, EventArgs e)
    {
        await LoadAsync()
            .ContinueWith(x => {
                if (!x.IsFaulted)
                {
                    _context = x.Result;
                    Text = "Loaded";
                    /* any other stuff on the main UI thread after loading */
                }
                else
                {
                    /* and don't forget that sometimes things fail */
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
    }
    private async Task<ProjectEntities> LoadAsync()
    {
        var context = new ProjectEntities();
        await context.Set(...).LoadAsync();
        return context;
    }
