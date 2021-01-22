    public MyForm ()
    {
        GuiFactory  factory = new Win32Factory ();
        Button      btn = factory.CreateButton ();
        
        btn.Text = "Go!"
        btn.Location = new Point (15, 50);
        
        this.Controls.Add (btn);
    }
