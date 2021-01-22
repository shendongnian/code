    protected void Page_Load(object sender, EventArgs e)
    {
        //add the event handler for the click event. You could provide other
        //logic to determine dynamically if the handler should be added, etc.
        btnButton1.Click += new EventHandler(btnButton1_Click);
        btnButton2.Click += new EventHandler(btnButton2_Click);
        btnButton3.Click += new EventHandler(btnButton3_Click);
    }
    
    protected void btnButton1_Click(object sender, EventArgs e)
    {
        //get the button, if you need to...
        Button btnButton1= (Button)sender;
    
        //do some stuff...
        DoA();
    }
    protected void btnButton2_Click(object sender, EventArgs e)
    {    
        //do some stuff...
        DoB();
    }
    protected void btnButton3_Click(object sender, EventArgs e)
    {    
        //do some stuff...
        DoC();
    }
    
    private void DoA() {}
    private void DoB() {}
    private void DoC() {}
