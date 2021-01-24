    interface IWeapon
    {
        void Shoot();
        void Reload();
        bool HasAmmo { get; }
        void MakeClickSound();
    }
