    public IList<Foo> GetAllFoosReferencingBar(Bar bar)
    {
        using (var tx = Session.BeginTransaction())
        {
            var result = Session.CreateCriteria(typeof(Foo))
                .Add(Restrictions.Eq("ReferencedBar", bar) // <--- Added restriction
                .List<Foo>();
            tx.Commit();
            return result; 
        }
    }
