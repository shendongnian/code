    public class Prop 
    { 
        public virtual void Shoot(params IProjectile[] projectiles) 
        { 
            // logic goes here... 
        } 
    } 
     
    public class Car : Prop 
    { 
        public override void Shoot(params IPaintBalls[] paintBalls)
        {
            base.Shoot(paintBalls);
        }
    } 
