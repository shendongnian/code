    public class DoorController : MonoBehaviour {
    
    	bool p1IsTouching = false;
    	bool p2IsTouching = false;
    
    	void Update() {
    		if (p1IsTouching && p2IsTouching) {
    			//do SceneManager stuff
    		}
    	}
    
    	void OnTriggerEnter2D(Collider2D other) {
    		if (other.gameObject.tag == "Player1") { p1IsTouching = true; }
    		if (other.gameObject.tag == "Player2") { p2IsTouching = true; }
    	}
    
    	void OnTriggerExit2D(Collider2D other) {
    		if (other.gameObject.tag == "Player1") { p1IsTouching = false; }
    		if (other.gameObject.tag == "Player2") { p2IsTouching = false; }
    	}
    }
