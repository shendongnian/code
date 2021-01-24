    public class EventTriggerActionService
    {
        static EventTriggerActionService()
        {
            ServiceLocator.RegisterService("name1", typeof(dependencyImpl1));
            ...
            ServiceLocator.RegisterService("nameN", typeof(dependencyImplN));
        }
    
        public void Execute(EventTriggerAction eventTriggerAction, EventContext context)
        {   
            var assemblyName = eventTriggerAction.EventAction.EventActionHandlerAssembly;
            var className = eventTriggerAction.EventAction.EventActionHandlerClass;
    
            Assembly actionHandlerAssembly = Assembly.Load(assemblyName);  
            var action = (ActionBase)Activator.CreateInstance(); // Instantiate the action by its base class, ActionBase
            action.Arguments = data.Arguments; // This is a dictionary that contains the arguments of the action
 
            action.Execute(); // Execute the Action
        }
    }
