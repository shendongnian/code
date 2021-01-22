    DateTime D;
    string CombinedDate=String.Format("{0}-{1}-{2}", YearField.Text, MonthField.Text, DayField.Text);
    if(DateTime.TryParseExact(CombinedDate, "yyyy-M-d", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out D)) {
      // valid
    } else {
      // not valid
    }
