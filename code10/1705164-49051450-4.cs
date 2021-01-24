    private void button1_Click(object sender, EventArgs e)
    {
        Timer timer = new Timer();
        // code here
        this.Controls.Add(timer);
    }
    private void button2_Click(object sender, EventArgs e)
    {    
        foreach (var ctrl in this.Controls.OfType<Timer>())
        {
            if (ctrl.Tag ==1)
            {
                ctrl.Stop();
                ctrl.Dispose();
            }
        }
    }
