    private void timer_Tick(object sender, EventArgs e)
    {
        try
        {
            // Disallow re-entry
            timer.Tick -= timer_Tick;
    		. . .
        }
        finally
        {
            timer.Tick += timer_Tick;
        }
    }
