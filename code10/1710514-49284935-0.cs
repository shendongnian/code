    public class TRigger : MonoBehaviour
    {
        void OnTriggerEnter(Collider other)
        {
            other.GetComponent<Changetext>().enabled = true;
        }
        
        void OnTriggerExit(Collider other)
        {
            other.GetComponent<Changetext>().enabled = false;
        }
    }
