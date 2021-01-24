    abstract class Powerup
    {
      private Powerup() {} // Prevent instantiation
      public virtual int Cooldown => 1
      public static readonly Powerup Freeze = new FreezePower();
      private sealed class FreezePower : Powerup
      {
      }
     
      public static readonly Powerup Burn = new BurnPower();
      private sealed class BurnPower : Powerup
      {
        public override int Cooldown => 2;
      }
    }
