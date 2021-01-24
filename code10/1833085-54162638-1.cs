        public class SuperClass : MonoBehaviour
    	{
    		[SerializeField] protected Camera _camera;
    		public SuperClass(Camera camera)
    		{
    			this._camera = camera;
    		}
    	}
    
    	public class SubClass : SuperClass
    	{
            // we just call constructor of SuperClass here and pass same
            // Camera object to our inherited member _camera
    		public SubClass(Camera camera) : base(camera)
    		{
    		}
    	}
