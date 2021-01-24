    sealed class FrenchDayInYear
    {
        private readonly string _dayOfYear;
        private readonly DateTimeFormatInfo _fr;
        public FrenchDayInYear(string dayOfYear)
        {
            _dayOfYear = dayOfYear;
            _fr = new CultureInfo("fr-FR").DateTimeFormat;
            _fr.AbbreviatedDayNames = new[] { "Lun", "Mar", "Mer", "Jeu", "Ven", "Sam", "Dim" };
        }
        public IReadOnlyList<DateTime> PossibleDates(int startYear)
        {
            return Enumerable.Range(startYear, DateTime.Now.Year - startYear)
                             .Select(WithYear)
                             .OfType<DateTime>()
                             .ToList();
        }
        private DateTime? WithYear(int year)
        {
            if (DateTime.TryParseExact(_dayOfYear + year, "ddd dd/MMyyyy", _fr, DateTimeStyles.None, out var result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }
    }
