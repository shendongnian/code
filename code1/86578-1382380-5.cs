    SinBuddy buddy = new SinBuddy();
    
    System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
    int loops = 200;
    
    // Math.Sin
    timer.Start();
    for (int i = 0; i < loops; i++)
    {
        for (double angleDegrees = 0; angleDegrees <= 360.0; 
            angleDegrees += buddy.CacheStep)
        {
            double d = buddy.Sin(angleDegrees);
        }
    }
    timer.Stop();
    MessageBox.Show(timer.ElapsedMilliseconds.ToString());
    
    // lookup
    timer = new System.Diagnostics.Stopwatch();
    timer.Start();
    for (int i = 0; i < loops; i++)
    {
        for (double angleDegrees = 0; angleDegrees <= 360.0;
            angleDegrees += buddy.CacheStep)
        {
            double d = buddy.SinLookup(angleDegrees);
        }
    }
    timer.Stop();
    MessageBox.Show(timer.ElapsedMilliseconds.ToString());
    
    // arrayed
    timer = new System.Diagnostics.Stopwatch();
    timer.Start();
    for (int i = 0; i < loops; i++)
    {
        for (double angleDegrees = 0; angleDegrees <= 360.0;
            angleDegrees += buddy.CacheStep)
        {
            double d = buddy.SinArrayed(angleDegrees);
        }
    }
    timer.Stop();
    MessageBox.Show(timer.ElapsedMilliseconds.ToString());
