     //string chopMe = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
     //int partLength = 12;
     //Stopwatch sw = new Stopwatch();
     sw = Stopwatch.StartNew();
     string s = chopMe;
     StringBuilder n = new StringBuilder();
     int chopSize = 0;
     while (!string.IsNullOrEmpty(s))
     {
          chopSize = s.Length > partLength ? partLength : s.Length;
          n.Append(s.Substring(0, chopSize) + "\r\n");
          s = s.Remove(0, chopSize);
      }
     sw.Stop();
     Console.WriteLine(sw.ElapsedTicks);
