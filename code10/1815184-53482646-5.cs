    public static IEnumerable<CostCenter> TakeWhileAndOneAfter
        (IEnumerable<CostCenter> source, DateTime splitDate )
    {
        DateTime? earliestDate = null;
        bool earliestFound = false;
        foreach (CostCenter element in source)
        {
            if (!earliestFound && !(element.start > splitDate))
            {
                earliestFound = true;
                earliestDate = element.start;
            }
            if (earliestFound)
            {
                if (element.start < earliestDate)
                {
                    break;
                }
                else
                {
                    element.start = splitDate;
                }
            }
            yield return element;
        }
    }
