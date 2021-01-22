    private void SetDateTimeFormatNames()
            {
    
                Thread.CurrentThread.CurrentCulture.DateTimeFormat.DayNames = ConvertoToTitleCase(Thread.CurrentThread.CurrentCulture.DateTimeFormat.DayNames);
                Thread.CurrentThread.CurrentCulture.DateTimeFormat.MonthNames = ConvertoToTitleCase(Thread.CurrentThread.CurrentCulture.DateTimeFormat.MonthNames);
    
            }
    
    private string[] ConvertoToTitleCase(string[] arrayToConvert)
                {
                    for (int i = 0; i < arrayToConvert.Length; i++)
                    {
                        arrayToConvert[i] = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(arrayToConvert[i]);
                    }
         
                    return arrayToConvert;
                }
