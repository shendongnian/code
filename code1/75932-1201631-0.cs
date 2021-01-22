         IList<Document> results = UnitOfWork.CurrentSession.CreateCriteria(typeof(Document))
                .Add(nh.Criterion.Restrictions.IdEq(obj.Id))
                .CreateCriteria("Owner","ow") // should try to always use aliases
                .Add(Restrictions.Eq("ow.UserId",yourUserId))
                .CreateCriteria("UserList","ul")
                .Add(Restrictions.Eq("ul.UserId",yourUserId))                
                .SetFirstResult(pageSize * page)
                .SetMaxResults(pageSize)
                .List<Document>();
