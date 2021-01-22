    public interface IProjectile { }
        public interface IPaintBall : IProjectile { }
        public interface IPotato : IProjectile { }
        public interface IShoot<T> where T : IProjectile
        {
            void Shoot(params T[] projectiles);
        }
    
        public interface IShootPaintBalls : IShoot<IPaintBall> { }
    
        public class Prop : IShoot<IProjectile>
        {
            public void  Shoot(params IProjectile[] projectiles)
            {
              // logic
            }
        }
    
        public class Car : Prop, IShootPaintBalls
        {
            public void  Shoot(params IPaintBall[] projectiles)
            {
                base.Shoot(projectiles);
            }
        }
