                public IList<B> GetAsBs(A aClass)
                {
                string hql = @"
                    SELECT B
                    FROM    A a
                    JOIN     a.ClassBs b
                    WHERE  A.ID = :ID
                ";
                IQuery query = Session.CreateQuery(hql);
                query.SetParameter("ID", aClass.ID);
    
                return query.List<B>();
    }
