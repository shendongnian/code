    DateTime[] startEnd = new DateTime[4];
    
    // Read data from table. 
    // For demonstration, array is here filled manually with your values:
    startEnd[0] = DateTime.Today.AddHours(8).AddMinutes(50);
    startEnd[1] = DateTime.Today.AddHours(10).AddMinutes(30);
    startEnd[2] = DateTime.Today.AddHours(12).AddMinutes(30);
    startEnd[3] = DateTime.Today.AddHours(15).AddMinutes(30);
    
    TimeSpan totalTime = new TimeSpan(0);
    
    // Add/subtract the timespans in pairs.
    for (int i = 0; i < 4 ; i += 2)
    {
    	totalTime += startEnd[i + 1].Subtract(startEnd[i]);
    }
    // Display totalTime as formatted text.
    Console.WriteLine(totalTime.ToString("hh':'mm"));
