    public class Item
    {
        public virtual int m_damage { get; set; }
    }
    
    public class Weapon : Item
    {
        public override int m_damage => 4;
    }
