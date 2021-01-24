    int Idx = 0;
    string days = "";
    var obj = new DaysDetails ();
    foreach (var p in s.GetType().GetProperties())
    {   days += (bool)p.GetValue(s) ? (days=="" ? Idx.ToString() : ","+Idx.ToString()) : "";
        Idx++;
    }
     Console.WriteLine(days); 
