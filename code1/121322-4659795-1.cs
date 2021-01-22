    var color = Dis.OrDat<string>(() => cake.frosting.berries.color, "blue");
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Linq.Expressions;
    
    namespace DeepNullCoalescence
    {
      public static class Dis
      {
        public static T OrDat<T>(Expression<Func><T>> expr, T dat)
        {
          try
          {
            var func = expr.Compile();
            var result = func.Invoke();
            return result ?? dat; //now we can coalesce
          }
          catch (NullReferenceException)
          {
            return dat;
          }
        }
      }
    }
