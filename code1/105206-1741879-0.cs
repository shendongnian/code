    Button adminButton = new Button();
    Button userButton = new Button();
    ...
    public void Form_Load(object sender, EventArgs e)
    {
        User user = // find user
        adminButton.Enabled = (user.Role == UserRoles.Admin)
        userButton.Enabled = (user.Role == UserRoles.Admin || user.Role == UserRoles.Standard)
    }
