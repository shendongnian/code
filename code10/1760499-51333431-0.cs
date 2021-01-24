    public class Woosh : MonoBehaviour
    {
        void OnCollisionEnter(Collision collisionInfo)
        {
            if (collisionInfo.collider.tag == "Player")
            {
                FindObjectOfType<AudioManager>().Play("Woosh");
            }
        }
    }
