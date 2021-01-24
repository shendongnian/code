    public class Item { }
    public class Weapon : Item
    {
        public int Damage { get; set; }
        public override string ToString()
        {
            return $"Damage: {Damage}";
        }
    }
    public class Armor : Item
    {
        public int AC { get; set; }
        public override string ToString()
        {
            return $"AC: {AC}";
        }
    }
    foreach (Item item in map.GetItems(0, 0))
        Console.WriteLine(item.ToString());
