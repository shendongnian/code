     public class DestroyParticles : MonoBehaviour
     {
         void Start()
         {
             Destroy(gameObject, GetComponent<ParticleSystem>().duration); 
         }
     }
