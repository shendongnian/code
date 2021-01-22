    public class Character
    {
        IWeapon weapon;
        public void GiveWeapon(IWeapon weapon)
        {
            this.weapon = weapon;
        }
        public void UseWeapon()
        {
            weapon.Use();
        }
    }
