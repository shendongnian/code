    public class CameraWaypoints : MonoBehaviour
    {
        public Transform[] CamPOVs;
        public float _speed = 0.1f;
        private Camera _main;
        private int _indexTargetCamera;        
        
        void Awake ()
        {
            _main = Camera.main;
        	_indexTargetCamera = 0;        	
        }
        
        void Update ()
        {
        	if (Input.GetKeyDown(KeyCode.Space))
        	{
        		_indexTargetCamera = ++_indexTargetCamera % CamPOVs.Length;
        	}
        
             var time = Time.deltaTime * _speed;
             // Alternatives to Lerp are MoveTowards and Slerp (for rotation)  
             var position = Vector3.Lerp(_main.transform.position, CamPOVs[_indexTargetCamera].position, time);
             var rotation = Quaternion.Lerp(_main.transform.rotation, CamPOVs[_indexTargetCamera].rotation, time);
           
        	_main.transform.position = position;
        	_main.transform.rotation = rotation;
        }
    }
