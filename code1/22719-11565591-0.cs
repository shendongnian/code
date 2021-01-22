    (from e in NHibernateSession().Query<Enquiry>()
    	where e.Property == (
    	(
    		from e2 NHibernateSession().Query<Enquiry>()
    		where e2.EnqueryCode == e.EnquiryCode
    		select e2.Property).Max()
    	)
    	select e
    ).ToList<Enquiry>()
