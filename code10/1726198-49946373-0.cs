    public static void Main()
    {
    var m_MinTemperature = 30M;
    var m_MaxTemperature = 66.9M;
    
    Console.WriteLine("#1:" + Math.Round(9.15M, 1, MidpointRounding.AwayFromZero));
    Console.WriteLine("#2:" + (9.15M).ToString("G17"));
    var r = ToCelcius(m_MinTemperature) + ToCelcius(m_MaxTemperature);
    Console.WriteLine("#3:" + r.ToString("G17")); 
    Console.WriteLine("#4:" + (r / 2M).ToString("G17"));
    Console.WriteLine("#5:" + Math.Round((r / 2M), 1, MidpointRounding.AwayFromZero).ToString("G17"));
    }
    
    
    static decimal ToCelcius(decimal fahrenheit)
    {
    	return Math.Round((fahrenheit - 32M) / 1.8M, 1, MidpointRounding.AwayFromZero);
    }	
