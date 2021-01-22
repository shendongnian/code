         IList<Document> results = UnitOfWork.CurrentSession.CreateCriteria(typeof(Document),"doc")
                .Add(nh.Criterion.Restrictions.IdEq(obj.Id))
                .CreateCriteria("doc.Owner","ow") // should try to always use aliases
                .Add(Restrictions.Eq("ow.UserId",yourUserId))
                .CreateCriteria("doc.UserList","ul")
                .Add(Restrictions.Eq("ul.UserId",yourUserId))                
                .SetFirstResult(pageSize * page)
                .SetMaxResults(pageSize)
                .List<Document>();
