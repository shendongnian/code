    public abstract class Item : ScriptableObject
    {
       // Properties that are common for all types of items
       public int weight;
       public Sprite sprite;
       public virtual void UseItem(Player player)
       {
          throw new NotImplementedException();
       }
    }
    [CreateAssetMenu(menuName = "Items/Create Potion")]
    public class Potion : Item
    {
       public int healingPower;
       public int manaPower;
       public override void UseItem(Player player)
       {
          Debug.Log(string.Format("You drank a {0}.", this.name));
          player.health += this.healingPower;          
          player.mana += this.manaPower;
       }
    }
    [CreateAssetMenu(menuName = "Items/Create Summon Orb")]
    public class SummonOrb : Item
    {
       public GameObject summonedCreaturePrefab;
       public override void UseItem(Player player)
       {
          Debug.Log(string.Format("You summoned a {0}", this.summonedCreaturePrefab.name));
          Instantiate(this.summonedCreaturePrefab);
       }
    }
