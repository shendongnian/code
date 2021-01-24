        public void MyFunction(List<Data> userData)
        {
            var beginDate = DateTime.Today;
            var endDate = DateTime.Today.AddYears(2);
            var monthsApart = 12 * (beginDate.Year - endDate.Year) + beginDate.Month - endDate.Month;
            var dateRange = Enumerable.Range(0, monthsApart).Select(offset => beginDate.AddMonths(offset));
            var difference = dateRange.Where(item => !(userData.Any(uData => uData.Year == item.Year && uData.Month == item.Month)));
            userData.AddRange(difference.Select(date => new Data() {Year = date.Year, Month = date.Month, Amount = 0}));
        }
