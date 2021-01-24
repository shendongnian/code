    abstract class Powerup
    {
      public virtual int Cooldown => 1
    }
    sealed class Freeze : Powerup
    {
    }
    sealed class Burn : Powerup
    {
      public override int Cooldown => 2;
    }
   
