    static string appDataFile;
    static void Main(string[] args)
    {
       string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
       appDataPath = System.IO.Path.Combine(appDataPath, "MyApplication");
       if (!System.IO.Directory.Exists(appDataPath))
          System.IO.Directory.CreateDirectory(appDataPath);
       appDataFile = System.IO.Path.Combine(appDataPath, "History.dat");
       
       DateTime[] dates;
       if (System.IO.File.Exists(appDataFile))
          dates = ReadDates();
       else
          dates = new DateTime[] {DateTime.Now, DateTime.Now};
       Console.WriteLine("First: {0}\r\nLast: {1}", dates[0], dates[1]);
       dates[1] = DateTime.Now;
       WriteDates(dates);
    }
    static DateTime[] ReadDates()
    {
       System.IO.FileStream appData = new System.IO.FileStream(
          appDataFile, System.IO.FileMode.Open, System.IO.FileAccess.Read);
       List<DateTime> result = new List<DateTime>();
       using (System.IO.BinaryReader br = new System.IO.BinaryReader(appData))
       {
          while (br.PeekChar() > 0)
          {
             result.Add(new DateTime(br.ReadInt64()));
          }
          br.Close();
       }
       return result.ToArray();
    }
    static void WriteDates(IEnumerable<DateTime> dates)
    {
       System.IO.FileStream appData = new System.IO.FileStream(
          appDataFile, System.IO.FileMode.Create, System.IO.FileAccess.Write);
       List<DateTime> result = new List<DateTime>();
       using (System.IO.BinaryWriter bw = new System.IO.BinaryWriter(appData))
       {
          foreach(DateTime date in dates)
             bw.Write(date.Ticks);
          bw.Close();
       }
    }
