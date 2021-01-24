    public static ILoungeService LoungeService { get; set; }
    public static ILoginService LoginService { get; set; } 
    public App ()
    {
        try
        {
            LoungeService = new LoungeService();
            LoginService = new LoginService();
        }
        catch(Exception e)
        {
            Debug.WriteLine(e);
            throw;
        }
        InitializeComponent();
        // ...
    }
