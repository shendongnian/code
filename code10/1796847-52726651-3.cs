    private string GetTimeString(TimeSpan elapsed)
    {
        result = string.Empty;
        //calculate difference in ticks
        diff = elapsed.Ticks - previousTicks;
        if (radioButton1.Checked == true)
        { //counting up
            ticksDisplayed += diff;
        }
        else
        { //counting down
            ticksDisplayed -= diff;
        }
        if (ticksDisplayed < 0)
        {
            ticksDisplayed = 0;
        }
        //Make ticksDisplayed to regular time to display in richtextbox
        TimeSpan ctimeSpan = new TimeSpan(ticksDisplayed);
        
        //HERE
        if( trackBarHours.Value != ctimeSpan.Hours ){ trackBarHours.Value = ctimeSpan.Hours; }
        if( trackBarMinutes.Value != ctimeSpan.Minutes){ trackBarMinutes.Value = ctimeSpan.Minutes; }
        if( trackBarSeconds.Value != ctimeSpan.Seconds){ trackBarSeconds.Value = ctimeSpan.Seconds; }
        result = string.Format("{0:00}:{1:00}:{2:00}.{3:000}",
            ctimeSpan.Hours,
            ctimeSpan.Minutes,
            ctimeSpan.Seconds,
            ctimeSpan.Milliseconds);
        previousTicks = elapsed.Ticks;
        return result;
    }
