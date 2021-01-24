    public class Item : ScriptableObject
    {
       // ...fields and so on...
       public void UseItem(Player player)
       {
          Debug.Log(string.Format("You used a {0}.", this.name));
          player.health += this.healingPower;          
          player.mana += this.manaPower;
          // ... and so on
       }
    }
