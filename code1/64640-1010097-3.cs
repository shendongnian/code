    const int size = 12;
    string s = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    StringBuilder n = new StringBuilder();
    int chopSize = 0;
    
    Stopwatch sw = new Stopwatch();
    sw.Start();
    while (!string.IsNullOrEmpty(s)) {
        chopSize = s.Length > size ? size : s.Length;
        n.Append(s.Substring(0, chopSize) + "\r\n");
        s = s.Remove(0, chopSize);
    }
    sw.Stop();
    
    Console.WriteLine(sw.ElapsedTicks);
