    public void Form_Load(object sender, EventArgs e)
    {
        List<PasswordEntry> entries = LoadEntries(@"C:\YourFile");
        foreach(PasswordEntry entry in entries)
        {
            Password pwd = new Password() { Directory = entry.Directory, Password = entry.Password };
            flowlayoutpanel1.Controls.Add(pwd);
        }
    }
