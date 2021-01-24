    static DateTime? NewestDateOrDefault(this IEnumerable<DateTime> dates)
    {
        IEnumerator<DateTime> enumerator = dates.GetEnumerator();
        if (!enumerator.MoveNext())
        {
            // sequence of dates is empty; there is no newest date
            return null;
        }
        else
        {   // sequence contains elements
            DateTime newestDate = enumerator.Current;
            while (enumerator.MoveNext())
            {   // there are more elements
                if (enumerator.Current > newestDate)
                   newestDate = enumerator.Current);
            }
            return newestDate;
        }
    }
