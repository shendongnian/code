    public class Player : MonoBehaviour
    {
       public void UseItem()
       {
          if (this.itemInHand != null)
          {
             this.itemInHand.UseItem(this);
          }
       }
    }
