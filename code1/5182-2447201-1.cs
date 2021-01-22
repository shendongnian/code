    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        MainUIForm mainUiForm = new MainUIForm();
        mainUiForm.Visible = false;
        Application.Run();
    }
