    public class Example : MonoBehaviour
    {
        void Reset()
        {
            transform.position =
               new Vector3(transform.position.x, 2.22f, transform.position.z);
            Debug.Log("Hi ...");
        }
    }
 
 
