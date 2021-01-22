    public interface IEffect<TContext>
    {
      public void Apply(TContext context);
    }
    public class SingleTargetContext
    {
      public Creature Target { get; set; }
    }
    public class AoEContext
    {
      public Point Target { get; set; }
    }
