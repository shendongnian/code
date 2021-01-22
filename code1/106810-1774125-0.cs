    DetachedCriteria dCriteria1 = DetachedCriteria.For<Project>("project")
    		.SetProjection(Projections.Property("project.Id"))
    		.Add(Restrictions.EqProperty("doc.projectId", "project.Id"));
    
    DetachedCriteria dCriteria2 = DetachedCriteria.For<Job>("job")
               .SetProjection(Projections.Property("job.Id"))	
    	       .CreateCriteria("Projects", "p")
    	       .Add(Restrictions.EqProperty("doc.jobId", "job.Id"))
    	       .Add(Restrictions.Eq("p.code", "somecode"));
    
    var documents = NHibernateSessionManager.Session.CreateCriteria<Document>("doc")
    		.Add(Restrictions.Or(
    	        Subqueries.Exists(dCriteria1),
    		    Subqueries.Exists(dCriteria2))).List<Document>();
