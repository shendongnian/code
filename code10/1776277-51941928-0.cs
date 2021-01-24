            List<string> dateStrings = new List<string>(new string[]
            {
                "11/15 8:00 AM",
                "1/5 9:00 PM"
            });
            var newDates = dateStrings
                .Select(x => DateTime.ParseExact(x, "M/d h:m tt", System.Globalization.CultureInfo.InvariantCulture))
                .Cast<DateTime>();
            foreach(var dd in newDates)
                System.Diagnostics.Debug.WriteLine(dd);
