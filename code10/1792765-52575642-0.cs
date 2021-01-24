    //I am counting everything in Stopwatch ticks
    private long diff = 0, previousTicks = 0, ticksDisplayed = 0;
    private string GetTimeString( TimeSpan elapsed ) {
        string result = string.Empty;
        
        //calculate difference in ticks
        diff = elapsed.Ticks - previousTicks;
        if( radioButton1.Checked == true ) { //or checkBoxCountUp.Checked == true
            ticksDisplayed += diff;
        }
        else {
            ticksDisplayed -= diff;
        }
        if( ticksDisplayed < 0) {
            ticksDisplayed = 0;
        }
        //Make ticksDisplayed to regular time to display in richtextbox
        TimeSpan ctimeSpan = new TimeSpan( ticksDisplayed );
 
        result = string.Format( "{0:00}:{1:00}:{2:00}.{3:000}",
            ctimeSpan.Hours,
            ctimeSpan.Minutes,
            ctimeSpan.Seconds,
            ctimeSpan.Milliseconds );
        previousTicks = elapsed.Ticks;
        return result;
    }
