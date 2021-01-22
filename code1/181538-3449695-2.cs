    public class Character
    {
        public Character(IWeaponBehavior weapon) 
        {
            this.weapon = weapon;
        }
        public void Attack()
        {
            weapon.UseWeapon();
        }
        IWeaponBehavior weapon;
    }
    public class Princess: Character
    {
        public Princess() : base(new Pan()) { }
    }
    public class Thief: Character
    {
        public Thief() : base(new Knife()) { }
    }
    ...
    Princess p = new Princess();
    Thief t = new Thief();
    p.Attack(); // pan
    t.Attack(); // knife
