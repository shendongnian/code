	// Get your NHiberate SessionFactory wherever that is in your application
	var sessionFactory = NHibernateHelper.SessionFactory;
	// Get an entity that you know is mapped by NHibernate
	var customer = new Customer();
	// Get a list of the database column names for the entity
	var columnNames = 
            Stackoverflow.Example.NHibernateHelper.GetPropertyColumnNames( sessionFactory, customer );
