     public enum Choices
     {
    	Default, // 0
    	ViewCurrentList, // 1
    	AddToList, // 2
    	DeleteFromList, // 3
     	ClearList, // 4
    	Exit // 5
     }
    
    static void Main(string[] args)
    {
    	int userInput = 0;
    	var toDo = new ToDo();
    	
    	do
    	{
    		userInput = ToDo.Menu();
    		//If input = 2, call the Add to List method
    		if (userInput == (int)Choices.AddToList)
    		{
    			toDo.AddToList();
    		}
    		
    		
    	} while (userInput != (int)Choices.Exit);	
     }
