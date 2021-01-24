    var zone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
    var utcNow = DateTime.UtcNow;
    var pacificNow = TimeZoneInfo.ConvertTimeFromUtc(utcNow, zone);
    MessageBox.Show((pacificNow  - new DateTime(1970, 01, 01))
         .TotalSeconds.ToString());
