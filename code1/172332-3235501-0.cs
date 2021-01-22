    public class Prop {
      public virtual void Shoot(params IProjectile[] projectiles) {
        ...
      }
    }
    public class Car : Prop {
      public override void Shoot(params IProjectile[] projectiles) {
        foreach (var p in projectiles) {
          if (!(p is IPaintBall)) {
            throw new ArgumentException("Only shoot cars with paint balls");
          }
        }
        Shoot(projectiles.Cast<IPaintBall>().ToArray());
      }
      public virtual void Shoot(params IPaintBall[] balls) {
        // Allow callers that are calling with paint balls (know at compile time)
        // to come in directly.
      }
    }
