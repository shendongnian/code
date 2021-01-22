    public IList<ChildCollectionType> GetChildObjectsByParentId(Int32 id)
    {
        ISession session = GetSession();//Get NHibernate session routine
        return session.Load<ParentDTO>(id).ChildCollectionProperty;
    }
