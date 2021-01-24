	public enum WeaponHandEnum
	{
		Primary //int = 0
		,
		Secondary //int = 1
	}
	public class Player
	{
		public Weapon[] Weapons {get;set;}
		public Player(Weapon primary = null, Weapon secondary = null)
		{
			Weapons = new Weapon[2] {primary, secondary}; 
		}
		public void Equip(WeaponHandEnum whichHand, Weapon newWeapon)
		{
			Weapons[(int)whichHand] = newWeapon;
		}
	}
	public class Weapon{ /* ... */ }
