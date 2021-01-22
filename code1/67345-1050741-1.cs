    public IEnumerable<T> FillInMissingDates<T>(IEnumerable<T> collection, 
        Func<T, DateTime> dateProperty, Func<T, string> descriptionProperty, string desc)
    {
        return collection.Except(collection
            .Where(d => descriptionProperty(d) == desc))
            .Select(d => dateProperty(d));
    }
