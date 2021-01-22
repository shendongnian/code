    DateTime myDate = DateTime.Now;
    CultureInfo culture = CultureInfo.CreateSpecificCulture("he-IL");
    culture.DateTimeFormat.Calendar = new HebrewCalendar(); // To be sure
    DateTimeStyles styles = DateTimeStyles.None;
    if (DateTime.TryParse("ג סיון תשן", culture, styles, out myDate))
    {
       // Hebrew date
    }
    culture = CultureInfo.CreateSpecificCulture("en-US");
    if (DateTime.TryParse("2/30/2010", culture, styles, out myDate))
    {
       // US date
    }
