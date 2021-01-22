    public interface IProjectile { }
    public interface IPaintBall : IProjectile { }
    public interface IPotato : IProjectile { }
    public abstract class Prop<TProjectile> where TProjectile : IProjectile
    {
        public void Shoot(params TProjectile[] projectiles)
        {
            
        }
    }
    public class Car : Prop<IPaintBall>
    {
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car();
            IPaintBall[] paintballs = PaintBallFactory.GetPaintBalls();
            myCar.Shoot(paintballs);
        }
    }
