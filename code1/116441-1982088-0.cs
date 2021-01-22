    var ad = AppDomain.CreateDomain("mydomain");
    ad.DoCallBack(() =>
      {
        var t = new System.Threading.Thread(() =>
        {
          Console.WriteLine();
          Console.WriteLine("app domain = " 
               + AppDomain.CurrentDomain.FriendlyName);
        });
        t.Start();
                
       });
