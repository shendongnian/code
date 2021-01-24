	var repository = new Repository();
	repository.Store("a", new TableA());
	repository.Store("b", new TableB());
	repository.Store("c", new TableC());
	repository.Store("d", new TableD());
	/* Somewhere else in your code */
	TableA a = repository.Fetch<TableA>("a");
	TableB b = repository.Fetch<TableB>("b");
	TableC c = repository.Fetch<TableC>("c");
	TableD d = repository.Fetch<TableD>("d");
