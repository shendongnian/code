        public static Dictionary<Tuple<int, int>, DateTime> MaxByYearMonth(this List<DateTime> sourceDateTimes)
        {
            IEnumerable<DateTime>                             ordered = sourceDateTimes.OrderBy(x => x.Ticks);
            IEnumerable<IGrouping<Tuple<int, int>, DateTime>> grouped = ordered.GroupBy(x => new Tuple<int, int>(x.Year, x.Month));
            Dictionary<Tuple<int, int>, DateTime>             maxed   = grouped.ToDictionary(x => x.Key, x => x.Max());
            return maxed;
        }
