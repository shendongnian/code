	public interface IState
	{
	 	string StateVar1 { get; }
	}
    public class State:IState
    {
        //Some example state information
        public string StateVar1 { get; private set; }
        //This method will be farmed out to multiple other threads
        public void Update(IState aDifferentStateObject)
        {
            StateVar1 = "I want to be able to do this";  // Allowed
            string infoFromAnotherObject = aDifferentStateObject.StateVar1; 
            aDifferentStateObject.StateVar1 = "I don't want to be able to do this, but I can"; // NOT allowed
        }
    }
	
	
