    public abstract class Personaje
    {
      public abstract bool Evade();
    }
    
    public class Poring : Enemigo
    {
      public override bool Evade()
      {
        return false;
      }
    }
