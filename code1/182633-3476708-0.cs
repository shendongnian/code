	public class MyViewModel : ViewModel
	{
		private readonly ICommand someCommand;
		
		public MyViewModel()
		{
			this.someCommand = new DelegateCommand(this.DoSomething, this.CanDoSomething);
		}
		
		public ICommand SomeCommand
		{
			get { return this.someCommand; }
		}
		
		private void DoSomething(object state)
		{
			// do something here
		}
		
		private bool CanDoSomething(object state)
		{
			// return true/false here is enabled/disable button
		}
	}
