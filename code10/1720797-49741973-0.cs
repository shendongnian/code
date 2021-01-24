    public class ParticlePlayer : MonoBehaviour
    {
    
        void OnTriggerEnter(Collider other)
        {
            //Make sure player is touching a touch
            if (other.CompareTag("torch"))
            {
                //Get ParticleSystem from the Gameobject the player collided with
                ParticleSystem ps = other.GetComponent<ParticleSystem>();
    
                //Play Particle
                ps.Play();
            }
        }
    
        void OnTriggerExit(Collider other)
        {
            //Make sure player is touching a touch
            if (other.CompareTag("torch"))
            {
                //Get ParticleSystem from the Gameobject the player collided with
                ParticleSystem ps = other.GetComponent<ParticleSystem>();
    
                //Stop Particle
                ps.Stop();
            }
        }
    }
