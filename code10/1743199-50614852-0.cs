    public class BasicWeapon
    {
        public static BasicWeapon CreateNew(WeaponData _weaponsData)
        {
            switch (_weaponsData.WeaponType)
            {
                case WeaponType.ProjectileWeapon:
                    return new ProjectileWeapon(_weaponsData);
                case WeaponType.Laser:
                    return new LaserWeapon(_weaponsData);
                case WeaponType.snowBall:
                    return new SnowballWeapon(_weaponsData);
            }
        }
    }
