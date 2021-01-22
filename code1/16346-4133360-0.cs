    Session.Clear();
    
    for (int i = 0; i < 1000; i++)
        Session[i.ToString()] = new object();
    
    Stopwatch sw1 = Stopwatch.StartNew();
    for (int i = 0; i < 1000; i++)
        Session[i.ToString()] = null;
    sw1.Stop();
    
    Session.Clear();
    
    for (int i = 0; i < 1000; i++)
        Session[i.ToString()] = new object();
    
    Stopwatch sw2 = Stopwatch.StartNew();
    for (int i = 0; i < 1000; i++)
        Session.Remove(i.ToString());
    sw2.Stop();
