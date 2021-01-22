    try
    {
      System.IO.StreamReader sr=new System.IO.StreamReader(@"c:\does-not-exist");
    }
    catch(Exception ex)
    {
      Console.WriteLine(ex.ToString()); //Will display localized message
      ExceptionLogger el = new ExceptionLogger(ex);
      System.Threading.Thread t = new System.Threading.Thread(el.DoLog);
      t.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
      t.Start();
    }
