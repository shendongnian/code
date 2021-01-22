    public interface IWeapon
    {
        void Kill();
    }
    public interface IShuriken : IWeapon
    {
        void Pierce();
    }
    public interface ISword : IWeapon
    {
        void Slice();
    }
