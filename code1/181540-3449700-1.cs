      class Character
      {
        private IWeaponBehavior _weapon;
     
        // Constructor
        public Character(IWeaponBehavior strategy)
        {
          this._weapon = strategy;
        }
     
        public void WeaponInterface()
        {
          _weapon.UseWeapon();
        }
      }
