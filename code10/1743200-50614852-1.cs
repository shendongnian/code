    public class BasicWeapon
    {
        public static BasicWeapon CreateNew(WeaponData _weaponsData)
        {
            // As @Gusman said in comments, if you store Type of classes in 
            // _weaponsData, then you can use :
            // return Activator.CreateInstance(_weaponsData.Type, _weaponsData);
            // Or:
            switch (_weaponsData.WeaponType)
            {
                case WeaponType.ProjectileWeapon:
                    return new ProjectileWeapon(_weaponsData);
                case WeaponType.Laser:
                    return new LaserWeapon(_weaponsData);
                case WeaponType.snowBall:
                    return new SnowballWeapon(_weaponsData);
                default: return null;
            }
        }
    }
