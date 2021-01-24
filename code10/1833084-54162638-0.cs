        public class SuperClass : MonoBehaviour
    	{
    		[SerializeField] protected Camera _camera { get; set; }
    		public SuperClass(Camera camera)
    		{
    			this._camera = camera;
    		}
    	}
    
    	public class SubClass : SuperClass
    	{
    		public SubClass(Camera camera) : base(camera)
    		{
    		}
    	}
