    var esCulture = new CultureInfo("es-ES");
    var monthNames = esCulture.DateTimeFormat.AbbreviatedMonthNames;
    for (int i = 0; i < monthNames.Length; i++) {
        monthNames[i] = monthNames[i].TrimEnd('.');
    }
    esCulture.DateTimeFormat.AbbreviatedMonthNames = monthNames;
    monthNames = esCulture.DateTimeFormat.AbbreviatedMonthGenitiveNames;
    for (int i = 0; i < monthNames.Length; i++)
    {
        monthNames[i] = monthNames[i].TrimEnd('.');
    }
    esCulture.DateTimeFormat.AbbreviatedMonthGenitiveNames = monthNames;
