    private System.Windows.Forms.Timer timer1;
    
    private void Form_Load(object sender, EventArgs e)
    {
         timer1 = new System.Windows.Forms.Timer();
         timer1.Interval = 900000;//5 minutes
         timer1.Tick += new System.EventHandler(Timer1_Tick);
    }
    
    private void Button1_Click(object sender, EventArgs e)
    {         
        if (!timer1.Enabled)
            timer1.Start();
    }
    private void Timer1_Tick(object sender, EventArgs e)
    {
        //do whatever you want 
         RefreshMyForm();
    }
    private void RefreshMyForm()
    {
        // What are you trying to achieve here? 
        // The "this" is referring to the form (not the button)
        this.Hide();
    
        // Do you want to place this graph on the form?
        Graph1 graph = new Graph1();
        graph.Show();
    
        // Consider showing the form again 
        this.Show();
    
    }
