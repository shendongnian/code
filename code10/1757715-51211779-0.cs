    public interface IWeapon
    {
        int Damage { get; }
        int Range { get; }
    }
    public class Weapon : IWeapon
    {
        protected int _damage, _range;
        public int Damage
        {
            get { return _damage; }
        }
        public int Range
        {
            get { return _range; }
        }
    }
    public class Sword : Weapon
    {
        public Sword()
        {
            _damage = 10;
            _range = 12;
        }
    }
    public class Bow : Weapon
    {
        public Bow()
        {
            _damage = 8;
            _range = 28;
        }
    }
    public class Hammer : Weapon
    {
        public Hammer()
        {
            _damage = 15;
            _range = 8;
        }
    }
