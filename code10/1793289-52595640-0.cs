    if( button1.Text == "START" ) {
        watch.Reset();
        //Here
        TimeSpan ctimeSpan = new TimeSpan( 0, trackBar1.Value, trackBar2.Value, trackBar3.Value, 0 );
        diff = 0;
        previousTicks = 0;
        ticksDisplayed = ctimeSpan.Ticks;
        watch.Start();
        button1.Text = "STOP";
        timer1.Enabled = true;
    }
    else {
        watch.Stop();
        button1.Text = "START";
        button2.Text = "PAUSE";
        timer1.Enabled = false;
    }
