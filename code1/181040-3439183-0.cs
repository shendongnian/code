    public Tab(string inputstring, MainForm formInstance) 
    { 
        ..... 
        //call this method if button is clicked 
        formInstance.cancel.Click += new System.EventHandler(formInstance.close_Click); 
        //ridiculous calculations to get the buttons in the right place 
        int leftside = ((formInstance.tabControl1.Width / 100) * 96); 
        int bottomside = ((formInstance.tabControl1.Height / 100) * 93); 
        int bottomside2 = ((formInstance.tabControl1.Height / 100) * 99); 
        ..... 
        //call this method if button is clicked 
        formInstance.save.Click += new System.EventHandler(formInstance.save_Click); 
        ..... 
        //call this method when tab is entered 
        formInstance.newtab.Enter += new System.EventHandler(formInstance.tabSelect); 
    }
