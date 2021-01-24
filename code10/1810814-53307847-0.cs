    var testQuery = context.Events
    	//.AsNoTracking() <-- No need when using projection
    	.OrderByDescending(@event => @event.Date)
    	.ThenBy(@event => @event.Name)
    	.Where(@event =>
    		!search.ProgramsChosen.Any() || @event.EventPrograms.Any(
    			eventProgram =>
    				search.ProgramsChosen.Contains(eventProgram.Program
    					.Name)))
    	.Select(e => new EventViewModel
    	{
    		Id = e.Id,
    		Name = e.Name,
    		Date = e.Date,
    		EventProgramViewModels = e.EventPrograms.Select(eventProgram =>
    			new EventProgramViewModel
    			{
    				ProgramViewModel = new ProgramViewModel
    				{
    					Name = eventProgram.Program.Name
    				}
    			}).ToList() // <-- 
    	})
    	.ToList()
    	;
