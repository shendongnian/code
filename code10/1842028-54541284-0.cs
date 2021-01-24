    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
    
        using (var icon = new NotifyIcon())
        {
            icon.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
    
            var contextMenu = new ContextMenu();
            var mnuProperties = new MenuItem()
            {
                Text = "Properties"
            };
            var mnuQuit = new MenuItem()
            {
                Text = "Quit"
            };
    
            mnuProperties.Click += mnuProperties_Click;
            mnuQuit.Click += mnuQuit_Click;
    
            contextMenu.MenuItems.Add(mnuProperties);
            contextMenu.MenuItems.Add(mnuQuit);
    
            icon.ContextMenu = contextMenu;
            icon.Visible = true;
    
            Application.Run();
        }
    }
    
    private static void mnuQuit_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }
    
    private static void mnuProperties_Click(object sender, EventArgs e)
    {
        var propertiesForm = new PropertiesForm();
        propertiesForm.Show();
    }
