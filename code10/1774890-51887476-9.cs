    public class Player : MonoBehaviour
    {
       public void PickUpItem(Item item)
       {
          this.playerItem = true;
          this.itemInHand = item;
          Debug.Log(string.Format("You picked up a {0}.", item.name));
       }
       public void UseItem()
       {
          if (this.itemInHand != null)
          {
             Debug.Log(string.Format("You used a {0}.", this.itemInHand.name));
          }
       }
    }
