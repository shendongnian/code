    public class Prop
    {
        protected void Shoot(params IProjectile[] projectiles)
        {
            // logic goes here...  
        }
    }
    public class Car : Prop
    {
        public void Shoot(params IPaintBall[] projectiles)
        {
            base.Shoot(projectiles);
        }
    }  
