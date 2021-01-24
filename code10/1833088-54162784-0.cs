public class SubClass :SuperClass 
{
     [SerializeField] Camera camera;
     void Awake()
     {
         if(camera!=null)
         {
             _camera=camera;
         }
     }
    // Start is called before the first frame update
    void Start()
    {
        camera=_camera;
    }
}
To further extend the solution, you could write a editor script or just get the camera from the code.
 
