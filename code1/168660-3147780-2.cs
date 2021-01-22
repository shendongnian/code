    public interface IBaseCopier<TFrom, TTo> where TFrom : Base, TTo : Base
    {
      void Copy(TFrom from, TTo to);
    }
    public class D1ToD2Copier : IBaseCopier<D1, D2>
    {
      public void Copy(D1 from, D2 to)
      {
        // Copy properties from the D1 instance to the D2 instance.
      }
    }
