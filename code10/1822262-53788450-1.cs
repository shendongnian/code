     public class EnemyDMG : MonoBehaviour
    {
      private int enemyHP;
      private ItemDrop getItem;
    private void Start()
    {
        enemyHP = Random.Range(50, 200);
        getItem = GetComponent<ItemDrop>();
       
      
           }
          // Below this code is inside of a simple OnCollisionEnter2D() function
         // The enemy damage is calculated inside of this same function
         // so I decided not to add any source code not directly relevant to my question
            if(enemyHP <= 0)
            {
                if (getItem != null)
                {
                    getItem.DropItem();
                    Debug.Log("Dropped an Item " + getItem);
                }
                Destroy(gameObject);
            }
       }
