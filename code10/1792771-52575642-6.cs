    private void trackBar1_Scroll( object sender, EventArgs e ) { //hour
        //get ticksDisplayed as TimeSpan
        TimeSpan ctimeSpan = new TimeSpan( ticksDisplayed );
        //change only the hour
        TimeSpan htimeSpan = new TimeSpan( ctimeSpan.Days, trackBar1.Value, ctimeSpan.Minutes, ctimeSpan.Seconds, ctimeSpan.Milliseconds );
        //set it to ticksDisplayed and update.
        ticksDisplayed = htimeSpan.Ticks;
        UpdateTime();
    }
    private void trackBar2_Scroll( object sender, EventArgs e ) { //min
        TimeSpan ctimeSpan = new TimeSpan( ticksDisplayed );
        TimeSpan mtimeSpan = new TimeSpan( ctimeSpan.Days, ctimeSpan.Hours, trackBar2.Value, ctimeSpan.Seconds, ctimeSpan.Milliseconds );
        ticksDisplayed = mtimeSpan.Ticks;
        UpdateTime();
    }
    private void trackBar3_Scroll( object sender, EventArgs e ) { //sec
        TimeSpan ctimeSpan = new TimeSpan( ticksDisplayed );
        TimeSpan stimeSpan = new TimeSpan( ctimeSpan.Days, ctimeSpan.Hours, ctimeSpan.Minutes, trackBar3.Value, ctimeSpan.Milliseconds );
        ticksDisplayed = stimeSpan.Ticks;
        UpdateTime();
    }
