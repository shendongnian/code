    public class Laser : MonoBehaviour 
    {
        public float speed = 10.0f;  
        public Vector3 laserTarget;
        public float destroyLaserAfterTime = 3f;
        
        private void Update () 
        {    
             transform.Translate(laserTarget * speed * Time.deltaTime);  
        }               
    }
