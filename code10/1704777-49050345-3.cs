	var ctr = new UnityContainer();
	var taskTypes = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.IsClass && typeof(IRunTask).IsAssignableFrom(x)).ToList();
    // Register from IRunTask to T using T.Name as a unique key for the name. You can add additional params like a lifetimemanager etc.
	taskTypes.ForEach(t => ctr.RegisterType(typeof(IRunTask), t, t.Name));
	var tasks = ctr.ResolveAll<IRunTask>().ToList(); // RT1, RT2, RT3
	tasks.ForEach(t => t.Run());
