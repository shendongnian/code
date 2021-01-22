    // this is the time to get the XML doc from the server, including the time to resolve DNS, get proxy etc.
    System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
    timer.Start();
    HttpWebResponse resp = (HttpWebResponse)request.GetResponse();
    timer.Stop();
    Console.WriteLine("XML download took: " + timer.ElapsedMilliseconds);
    timer.Start();
    // now, do your XLinq stuff here...
    timer.Stop();
    Console.WriteLine("XLinq took: " + timer.ElapsedMilliseconds);
