	public abstract class ActionBase
	{
		protected IEmailer Emailer { get; set; }
		protected Dictionary<string,string> Arguments { get; set; }
		public void Execute()
		{
			// Do something with Emailer.
			ExecuteAction(); // Execute the custom action
		}
		public abstract ResultBase ExecuteAction();
	}
	public class EventTriggerActionService
	{
		// omit for readability	
		public void Execute(EventTriggerAction eventTriggerAction, EventContext context)
		{   
			// omit for readability
			
			var action = (ActionBase)Activator.CreateInstance(); // Instantiate the action by its base class, ActionBase
			action.Arguments = data.Arguments; // This is a dictionary that contains the arguments of the action
			action.Emailer = _emailerFactory.Create();
			// omit for readability
		}
		// omit for readability
	}
