    public class MyCoolViewModel
    {
	   bool runSequentially = false;
	
	   public ReactiveCommand<Unit, Unit> Command { get; set; }
	   public ReactiveCommand<Unit, Unit> Command2 { get; set; }
	   public ReactiveCommand<Unit, Unit> Command3 { get; set; }
	   public ReactiveCommand<Unit, Unit> CommandwhoInvokesOtherCommands { get; set; }
	
	
	   public MyCoolViewModel()
	   {
		
		   Command = ReactiveCommand.CreateFromTask<Unit, Unit>(async _ =>
		   {	
		  	runSequentially= false;
			Console.WriteLine("Start 1");
			await Task.Delay(1000);
			Console.WriteLine("End 1");
			return Unit.Default;
		   });
		  Command2 = ReactiveCommand.CreateFromTask<Unit, Unit>(async _ =>
		  {
 		  	runSequentially = false;
			Console.WriteLine("Start 2");
			await Task.Delay(1000);
			Console.WriteLine("End 2");
			return Unit.Default;
		  });
		Command3 = ReactiveCommand.CreateFromTask<Unit, Unit>(async _ =>
		{
			Console.WriteLine("Start 3");
			await Task.Delay(1000);
			Console.WriteLine("End 3");
			return Unit.Default;
		});
		CommandwhoInvokesOtherCommands = ReactiveCommand.CreateFromTask<Unit, Unit>(async _ =>
		  {
			  Console.WriteLine("Invoking other commands");
			  runSequentially = true;
			  await Task.Delay(1000);
			  Console.WriteLine("End");
			  return Unit.Default;
		  });
                /*Command 1, 2 and 3 only will run if flag is set to true*/
		CommandwhoInvokesOtherCommands.Where(_ => runSequentially).InvokeCommand(Command);
		Command.Where(_ => runSequentially).InvokeCommand(Command2);
		Command2.Where(_ => runSequentially).InvokeCommand(Command3);
		
		//Observable.Return(Unit.Default).InvokeCommand(CommandwhoInvokesOtherCommands);//for test purposes
	}
    }
