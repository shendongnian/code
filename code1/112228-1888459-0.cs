            DateTime result;
            DateTime startTime = new DateTime;
            if (DateTime.TryParseExact(date1, formats,
                              new CultureInfo("en-US"),
                              DateTimeStyles.None,
                              out result))
            {
                startTime = result;
            }
            Console.Write(startTime);
