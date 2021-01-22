    public delegate Decimal GetProperty<TElement>(TElement element);
    public static Decimal Max<TElement>(IEnumerable<TElement> enumeration, 
                                        GetProperty<TElement> getProperty)
    {
        Decimal max = Decimal.MinValue;
        foreach (TElement element in enumeration)
        {
            Decimal propertyValue = getProperty(element);
            max = Math.Max(max, propertyValue);
        }
        return max;
    }
