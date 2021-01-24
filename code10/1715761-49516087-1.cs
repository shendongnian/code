    public static void PrintCultureDateTime(string culture)
        {
            string result = new DateTime(2017, 10, 1).ToString("d", new 
    CustomFormatProvider(culture));
            Console.WriteLine(string.Format("{0}: {1}", culture, result));
        }
