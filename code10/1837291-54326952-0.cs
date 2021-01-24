    public Color TemperatureRange(double BlueToRed)
    {
    	double r, g, b;
    
    	//From blue to green
    	if(BlueToRed < 0)
    	{
    		r = 0;
    		g = 1 + BlueToRed;
    		b = -BlueToRed;
    	}
    	
    	//From green to red
    	else
    	{
    		r = BlueToRed;
    		g = 1 - BlueToRed;
    		b = 0;
    	}
    	
    	return Color.FromArgb((int)(r*255), (int)(g*255), (int)(b*255));
    }
