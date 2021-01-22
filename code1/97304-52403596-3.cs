     public static string PrintSeasons()
        {
            DateTime checkDateTime = new DateTime(2010, 1, 1);
            DateTime stopDateTime = new DateTime(2050, 1, 1);
            List<KeyValuePair<string, DateTime>> Seasons = new List<KeyValuePair<string, DateTime>>();
            while (checkDateTime < stopDateTime)
            {
                DateTime switchTime = checkDateTime;
                switch (getSeason(switchTime))
                {
                    case 0: //Spring
                        if (switchTime.Month == 3 && switchTime.Day > 18 && switchTime.Day < 22)
                        {
                            KeyValuePair<string, DateTime> seasonEntry = new KeyValuePair<string, DateTime>("Spring", switchTime);
                            if (!Seasons.Any(o => o.Key == "Spring" && o.Value.Year == seasonEntry.Value.Year))
                                Seasons.Add(seasonEntry);
                        }
                        break;
                    case 1: //Summer
                        if (switchTime.Month == 6 && switchTime.Day > 19 && switchTime.Day < 22)
                        {
                            KeyValuePair<string, DateTime> seasonEntry = new KeyValuePair<string, DateTime>("Summer", switchTime);
                            if (!Seasons.Any(o => o.Key == "Summer" && o.Value.Year == seasonEntry.Value.Year))
                                Seasons.Add(seasonEntry);
                        }
                        break;
                    case 2: //Autumn
                        if (switchTime.Month == 9 && switchTime.Day >= 19 && switchTime.Day < 25)
                        {
                            KeyValuePair<string, DateTime> seasonEntry = new KeyValuePair<string, DateTime>("Autumn", switchTime);
                            if (!Seasons.Any(o => o.Key == "Autumn" && o.Value.Year == seasonEntry.Value.Year))
                                Seasons.Add(seasonEntry);
                        }
                        break;
                    case 3: //Winter
                        if (switchTime.Month == 12 && switchTime.Day > 19 && switchTime.Day < 23)
                        {
                            KeyValuePair<string, DateTime> seasonEntry = new KeyValuePair<string, DateTime>("Winter", switchTime);
                            if (!Seasons.Any(o => o.Key == "Winter" && o.Value.Year == seasonEntry.Value.Year))
                                Seasons.Add(seasonEntry);
                        }
                        break;
                }
                checkDateTime = checkDateTime.AddDays(1);
            }
            DateTime currentYear = new DateTime(2000, 1, 1);
            string test = currentYear.Year + " | ";
            foreach (var season in Seasons)
            {
                if (currentYear.Year != season.Value.Year)
                {
                    test += Environment.NewLine + season.Value.Year + " | ";
                    currentYear = season.Value;
                }
                test += season.Key + ": " + season.Value.ToString("dd") + " | ";
            }
            return test;
        }
