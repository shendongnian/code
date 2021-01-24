	bool test;
	
	bool condition = DateTime.Now > DateTime.Now;
	if (condition)
	{
		Assign(out test);
	}
	
	if (test) { ... }
