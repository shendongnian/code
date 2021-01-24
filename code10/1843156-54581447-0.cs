    var date = new DateTime(2019, 1, 28);
    var usEnglishCulture = new CultureInfo("en-US");
    var spainSpanishCulture = new CultureInfo("es-ES");
            
    Console.WriteLine(date.ToString(usEnglishCulture.DateTimeFormat.LongDatePattern), 
        usEnglishCulture);
    Console.WriteLine(date.ToString(spainSpanishCulture.DateTimeFormat.LongDatePattern, 
        spainSpanishCulture));
