    string s;
    try
    {
        //do work
    }
    catch
    {
       if (!String.IsNullOrEmpty(s))
       {
           //safely access s
           Console.WriteLine(s);
       }
    }
