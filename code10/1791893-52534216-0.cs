    Timer timer1 = new Timer { Interval = 10000, Enabled = True };
    Timer timer2 = new Timer { Interval = 300000, Enabled = True };
    Timer timer3 = new Timer { Interval = 3600000, Enabled = True };
    
    timer1.Tick += (s,e) => { Your code 10 Sec };
    timer2.Tick += (s,e) => { Your code 5 Min };
    timer3.Tick += (s,e) => { Your code 1 Hour };
