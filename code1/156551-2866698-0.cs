    private void mouseWheelHandler (object sender, MouseEventArgs e)
        {
        slowTimer.Enabled = false;
        slowTimer.Stop ();            
        slowTimer.Interval = 200;
        slowTimer.Start();
        slowTimer.Enabled = true;
        m_counter++;
        Trace.WriteLine(string.Format("counter={0}", m_counter));
        if (fastTimer.Enabled==false)
            {
            fastTimer.Enabled = true;
            fastTimer.Interval = 150;
            fastTimer.Start ();
            }
        if (m_counter>5)
            {
            Trace.WriteLine("called method 2");
            m_counter = 0;
            fastTimer.Stop ();
            slowTimer.Enabled = false;
            slowCheckTimer.Stop ();                
            slowCheckTimer.Interval = 250;
            slowCheckTimer.Start();
            slowCheckTimer.Enabled = true;
            }
        }
    private void slowTimer_Tick(object sender, EventArgs e)
        {
        Trace.WriteLine("slow timer ticked");
        if (slowCheckTimer.Enabled==false)
            {
            Trace.WriteLine ("called method 1");
            }
        
        slowTimer.Enabled = false;
        }
    private void fastTimer_Tick(object sender, EventArgs e)
        {
        fastTimer.Enabled = false;
        Trace.WriteLine("fast timer ticked");
        m_counter = 0;
        fastTimer.Stop ();
        }
    private void slowCheckTimer_Tick(object sender, EventArgs e)
        {
        Trace.WriteLine("slow check timer ticked");
        slowCheckTimer.Stop ();
        slowCheckTimer.Enabled = false;
        }
