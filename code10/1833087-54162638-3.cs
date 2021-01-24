    public static class StaticValues
    {
    	public static Camera Camera {get; set;} 
    }
    public class SuperClass : MonoBehaviour
    {
    	[SerializeField] protected Camera _camera
    	{
    		get
    		{
    			return StaticValues.Camera;
    		}
    		set
    		{
    			StaticValues.Camera = value;
    		}
    	}
    }
    public class SubClass : SuperClass
    {
    	
    }
