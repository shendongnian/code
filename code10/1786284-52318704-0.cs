    public interface IC1
    {
        int prop1 { get; set; }
    }
    public interface IC2
    {
        int prop2 { get; set; }
    }
    public abstract class C1 : IC1
    {
        #region Implementation of IC1
        public int prop1 { get; set; }
        #endregion
    }
    public class C2 : C1, IC2
    {
        #region Implementation of IC2
        public int prop2 { get; set; }
        #endregion
    }
    public abstract class P1
    {
        public abstract void Run<T>(T c) where T : IC1, IC2;
    }
    public class P2 : P1
    {
        public override void Run<T>(T c)
        {
            c.prop1 = 1; 
            c.prop2 = 2; 
        }
    }
