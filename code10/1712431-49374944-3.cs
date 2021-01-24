    public class KeyboardButton : MonoBehaviour 
    {
    
    	public void buttonClick () 
    	{
    		controller = 1;
    		
    		GameObject.Find("name of object").SendMessage("sendValue",controller);
    	}
    }
