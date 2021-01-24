    public class WeaponFactory {
        public static IWeapon GetWeapon(int choice)
        {
            IWeapon weapon = null;
            switch (choice)
            {
                case 1:
                    weapon = new Glock18();
                    break;
            }
            return weapon;
        }
    }
