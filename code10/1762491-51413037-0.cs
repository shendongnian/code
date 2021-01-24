    public class Enemy : MonoBehaviour
    {
      void OnTriggerEnter2D ( Collider2D other )
      {
        other.GetComponent<Renderer>().material.color = Color.green;
      }
    
      void OnTriggerExit2D ( Collider2D other )
      {
        other.GetComponent<Renderer>().material.color = Color.red;
      }
    }
