    public static IList<T> LoadObjectListAll<T>()
    {
        ISession session = CheckForExistingSession();
        // Not sure if you can configure a session after retrieving it.  CheckForExistingSession should have this logic.
        // var cfg = new NHibernate.Cfg.Configuration().Configure();
        var criteria = session.CreateCriteria(typeof(T));
        return criteria.List<T>();
    }
