    class WeaponFactory
    {
        public static IWeapon CreateWeapon(WeaponType type)
        {
            switch type:
                case WeaponType.Sword: return new Sword();
                case WeaponType.Hammer: return new Hammer();
                case WeaponType.Bow: return new Bow();
                default: throw new ArgumentException("Unknown weaponType");
        }
    }
    enum WeaponType { Sword, Hammer, Bow }
    interface IWeapon
    {
        int Damage { get; }
        int Range { get; }
    }
