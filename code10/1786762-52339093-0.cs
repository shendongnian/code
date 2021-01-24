    public class P2 : MonoBehaviour
    {
       public GameObject p3;
       void OnCollisionEnter(Collision col) 
       { 
            if(col.gameObject.name == "p")
            {
               Debug.Log("Collision detected");
               p3.GetComponent<Renderer>().enabled = false;
            }
       } 
    }
