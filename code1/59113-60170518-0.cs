    Convert.ChangeType("2020-12-31", typeof(DateTime));
    Convert.ChangeType("2020/12/31", typeof(DateTime));
    Convert.ChangeType("2020-01-01 16:00:30", typeof(DateTime));
    Convert.ChangeType("2020/12/31 16:00:30", typeof(DateTime), System.Globalization.CultureInfo.GetCultureInfo("en-GB"));
    Convert.ChangeType("11/شعبان/1437", typeof(DateTime), System.Globalization.CultureInfo.GetCultureInfo("ar-SA"));
    Convert.ChangeType("2020-02-11T16:54:51.466+03:00", typeof(DateTime)); // format: "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffzzz"
