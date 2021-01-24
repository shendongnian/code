    public class OneObject : MonoBehaviour {
    
        void OnEnable() {
            GameObject[] otherObjects = GameObject.FindGameObjectsWithTag("obj");
            
            foreach (GameObject obj in otherObjects) {
                Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>()); 
            }
            // rest of Start
        }
       // rest of class ...
    }
