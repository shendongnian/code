    private DateTime mousePressed;
    private void txtBlockOnOff_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        mousePressed = DateTime.Now;
    }
    private void txtBlockOnOff_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        // button released
        TimeSpan difference = DateTime.Now - mousePressed;
        if (difference.TotalSeconds >= 3)
        {
            // long press
        }
        else
        {
            // short press
        }
    }
