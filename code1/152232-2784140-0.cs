    public override Control GetAdministrationInterface()
    {
        // more code...
    
        Button btn = new Button();
        btn.Text = "Click Me!";
        // !!THE BANE OF MY EXISTENCE!!
        btn.ID = "The_Bane_of_My_Existence";
        // !!THE BANE OF MY EXISTENCE!!
        btn.Click += new EventHandler(Btn_Click);
    
        // more code...
    }
