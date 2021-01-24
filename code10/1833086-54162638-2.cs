    public static class StaticValues
    {
    	public static Camera camera; 
    }
    public class SuperClass : MonoBehaviour
    {
    	[SerializeField] protected Camera _camera
    	{
    		get
    		{
    			return StaticValues.camera;
    		}
    		set
    		{
    			StaticValues.camera = value;
    		}
    	}
    }
    public class SubClass : SuperClass
    {
    	
    }
