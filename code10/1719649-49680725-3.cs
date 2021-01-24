    Controller<TableA> Controller1 = new Controller<TableA>(new TableA());
    Controller<TableB> Controller2 = new Controller<TableB>(new TableB());
	Controller<TableC> Controller3 = new Controller<TableC>(new TableC());
		
	List<ICanSync> ControllerList = new List<ICanSync> {Controller1, Controller2, Controller3};
		
	foreach (var controller in ControllerList) 
	{
		controller.Synchronize();
	}
