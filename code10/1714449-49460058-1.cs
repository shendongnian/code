    // Add this "using" directive
    using UnityEngine.EventSystems;
    // Be sure to implement the interface of IPointerClickHandler
    public class NameOfYourScript : MonoBehaviour, IPointerClickHandler {
    
        //
        // Additional Code in your class. . . .
        // 
        // Replace OnMouseDown() with this.
        public void OnPointerClick(PointerEventData pointerEventData) {
            Instantiate(bullet_player);
            
            Vector2 playerPosition = new Vector2();
            playerPosition.x = GameObject.Find("player-1").transform.position.x;
            playerPosition.y = GameObject.Find("player-1").transform.position.y;
            
            Vector2.MoveTowards(playerPosition, pointerEventData.position, p1BulletSpeed);
        }
    }
