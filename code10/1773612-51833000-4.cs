    abstract class Item
	{
		public abstract void Equip(Player player);
	}
	
	abstract class Armour : Item
	{
	}
	
	class ChestPlate : Armour
	{
		public override void Equip(Player player)
		{
			player.Chest = this;
		}
	}
	
	class Helm : Armour
	{
		public override void Equip(Player player)
		{
			player.Helmet = this;
		}
	}
	
	class Weapon : Item
	{
		public override void Equip(Player player)
		{
			player.MainHand = this;
		}
	}
	
	class OneHandedWeapon : Weapon
	{
	}
	
	class TwoHandedWeapon : Weapon
	{
		public override void Equip(Player player)
		{
			player.Offhand = player.MainHand = this;
		}
	}
		
	class Player
	{
		public Armour Helmet { get; set; }
		public Armour Chest { get; set; }
		public Weapon MainHand { get; set; }
		public Item Offhand { get; set; }
	}
