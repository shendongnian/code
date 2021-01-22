    public static DateTime CompileTime
    {
       get
       {
          System.Version MyVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
          // MyVersion.Build = days after 2000-01-01
          // MyVersion.Revision*2 = seconds after 0-hour  (NEVER daylight saving time)
          DateTime compileTime = new DateTime(2000, 1, 1).AddDays(MyVersion.Build).AddSeconds(MyVersion.Revision * 2);                
          return compileTime;
       }
    }
