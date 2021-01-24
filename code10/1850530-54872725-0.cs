    public interface IWeapon
    {
        void Shoot();
        float Damage { get; }
    }
    public class Sword : IWeapon
    {
        public void Shoot() { } //does nothing
        private float _damage { get; set; }
        public float Damage { get { return _damage; } }
        public Sword(int damage)
        {
            _damage = damage;
        }
    }
