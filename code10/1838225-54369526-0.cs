	for(var i = 0; i < tasks.Count(); i++)
	{	
        //You can remove the i>0 check if you want to output a break at the start
		if (i % TasksPerPage == 0 && i > 0)
		{
			Console.WriteLine("Page Break");
		}
		Console.WriteLine(tasks[i]);
	}
