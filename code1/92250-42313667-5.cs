    while (1 < 2)
    {
    	Random r = new Random();
    
    	// Get a random fore- and backcolor
    	Color foreColor = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));
    	Color backColor = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));
     
    	// Contrast readable?
    	if (ContrastReadableIs(foreColor, backColor))
    	{
    		button1.ForeColor = foreColor;
    		button1.BackColor = backColor;
    		System.Media.SystemSounds.Beep.Play();
    		break;
    	}
    }
