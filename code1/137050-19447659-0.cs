	NHibernate.Cfg.Configuration config = new Configuration();
	/*
	The initialisation here like config.AddAssembly(... and so forth
	*/
	NHibernate.Mapping.Table table = config.GetClassMapping(typeof(T)).RootTable;
	String NameOfTableOfInterest = table.Name;
