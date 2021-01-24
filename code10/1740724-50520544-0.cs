    interface ITileDamage
    {
        int ApplyDamage(Tile t);
    }
    
    public class Tile
    {
        int Layer { get; set; }
        ITileDamage Damage { get; set; }
    }
