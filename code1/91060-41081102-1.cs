        private static IEnumerable<T> FillInEmptyDates<T>(IEnumerable<DateTime> allDates, IEnumerable<T> sourceData, Func<T, DateTime> dateSelector, Func<DateTime, T> defaultItemFactory)
        {
            // iterate through the source collection
            var iterator = sourceData.GetEnumerator();
            iterator.MoveNext();
            // for each date in the desired list
            foreach (var desiredDate in allDates)
            {
                // check if the current item exists and is the 'desired' date
                if (iterator.Current != null && 
                    dateSelector(iterator.Current) == desiredDate)
                {
                    // if so then return it and move to the next item
                    yield return iterator.Current;
                    iterator.MoveNext();
                    // if source data is now exhausted then continue
                    if (iterator.Current == null)
                    {
                        continue;
                    }
                    // ensure next item is not a duplicate 
                    if (dateSelector(iterator.Current) == desiredDate)
                    {
                        throw new Exception("More than one item found in source collection with date " + desiredDate);
                    }
                }
                else
                {
                    // if the current 'desired' item doesn't exist then
                    // create a dummy item using the provided factory
                    yield return defaultItemFactory(desiredDate);
                }
            }
        }
