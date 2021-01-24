    public class Collect : MonoBehaviour 
    {
        private void OnTriggerEnter(Collider c0ol)
        {
            Debug.Log("Registered Trigger");
        }
        private void OnCollisionEnter(Collision col)
        {
            Debug.Log("Registered Collision");
        }
    }
