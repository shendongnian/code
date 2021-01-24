    public class ItemDisplay : MonoBehaviour
    {
       void OnTriggerEnter(Collider other)
       {
          if (other.gameObject.tag == "Player")
          {
             var playerPickUp = other.gameObject;
             var playerScript = playerPickUp.GetComponent<Player>();
             var playerItem = playerScript.playerItem;
             // This is where you would pass the item to the Player script
             playerScript.pickUpItem(this.item);
             bool isActive = true;
             Object.Destroy(gameObject);
          }
       }
    }
