    CultureInfo enUS = new CultureInfo("en-US");
    string path = ConfigurationRead.GetAppSetting("ReportDirectory");
    DateTime currentDate = DateTime.Now.AddDays(-7);
    foreach (string s in Directory.GetDirectories(path))
    {
         string folderPath = s.Remove(0, path.Length);
         if (DateTime.TryParseExact(folderPath, "dd-MM-yyyy hhmmss", enUS, DateTimeStyles.AssumeLocal, out DateTime td))
         {
              if (td <= currentDate)
              {
                   Directory.Delete(s, true);
              }
         }
    }
