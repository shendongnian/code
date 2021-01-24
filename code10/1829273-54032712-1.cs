     public class DestroyParticles : MonoBehaviour
     {
         void Start()
         {
             Destroy(this.gameObject, GetComponent<ParticleSystem>().main.duration); 
         }
     }
