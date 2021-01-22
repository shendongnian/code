    // create a System.Windows.Forms.Timer through the designer or in code.
    // give it a short interval if you want the counter to increment quickly.
    int counter;
    private void Form1_Load(object sender, EventArgs e)
    {
        ...
        t.Start();
        counter = 0;
        timer.Start();
        ....
    }
    private void timer_Tick(object sender, EventArgs e)
    {
       if (t.IsAlive)
       {
           counter++;
           toolStripStatusLabel1.Text = counter.ToString(); 
       }
       else
       {
          timer.Stop();
       }
    }
