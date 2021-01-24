                string firstDate = "10-08-2018";
                DateTime _firstDate = DateTime.ParseExact(firstDate, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
                string secondDate = "10-08-2018";
                DateTime _secondDate = DateTime.ParseExact(secondDate, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
                if (_firstDate >= DateTime.ParseExact("15-06-2018", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture) &&
                    _secondDate <= DateTime.ParseExact("15-08-2018", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture))
                {
                }
