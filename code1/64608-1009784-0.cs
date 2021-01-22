    public Form1()
    {   
        this.MouseEnter += new System.EventHandler(this.Form1_MouseEnter);
        this.MouseLeave += new System.EventHandler(this.Form1_MouseLeave);
    }
    
    private void Form1_MouseLeave(object sender, EventArgs e)
    {
        this.Opacity = 0.5;
    }
    
    private void Form1_MouseEnter(object sender, EventArgs e)
    {
        this.Opacity = 1;
    }
