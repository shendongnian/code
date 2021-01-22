    public class Prop<T> where T : IProjectile
    {
        public virtual void Shoot(params T[] projectiles)
        {
            // logic goes here... 
        }
    }
    public class Car : Prop<IPaintBall>
    {
    } 
