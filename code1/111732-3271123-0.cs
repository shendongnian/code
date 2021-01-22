    public static DetachedCriteria Clone(this DetachedCriteria criteria)
    {
       var dummy = criteria.ToByteArray();
       return dummy.FromByteArray<DetachedCriteria>();
    }
