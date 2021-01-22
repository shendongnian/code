    private void PollPixel(Point location, Color color)
    {
        while(true)
        {
            var c = GetColorAt(location);
    
            if (c.R == color.R && c.G == color.G && c.B == color.B)
            {
                DoAction();
                return;
            }
            // By calling Thread.Sleep() without a parameter, we are signaling to the
            // operating system that we only want to sleep long enough for other
            // applications.  As soon as the other apps yield their CPU time, we will
            // regain control.
            Thread.Sleep()
        }
    }
