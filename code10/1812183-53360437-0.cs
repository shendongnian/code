    //initialized from image
	double red = 0, green = 0, blue = 0;
		
	double r_output = (red > 0.04045) ? 
                      System.Math.Pow((red + 0.055) / (1.0 + 0.055), 2.4) : 
                      (red / 12.92);
    double g_output = (green > 0.04045) ? 
                      System.Math.Pow((green + 0.055) / (1.0 + 0.055), 2.4) : 
                      (green / 12.92);
    double b_output = (blue > 0.04045) ? 
                      System.Math.Pow((blue + 0.055) / (1.0 + 0.055f), 2.4) : 
                      (blue / 12.92); 
