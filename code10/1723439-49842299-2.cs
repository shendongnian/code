    // Destroys barriers on collision
    public sealed class BarrierBoundary : MonoBehaviour
    {
        // Called once the script is created
        // Checks if the object has Rigidbody component attached
        private void Awake()
        {
            Debug.Assert(GetComponent<Rigidbody>() != null);
        }
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.collider.tag == "Barrier")
                Destroy(collision.collider.gameObject);
        }
    }
