    public static dynamic Cast(object obj, Type t)
    {
         if (obj is IConvertible)
         {
            return Convert.ChangeType(obj, t) as dynamic;
         }
         else
         {
             try
             {
                 var param = Expression.Parameter(typeof(object));
                 return Expression.Lambda(Expression.Convert(param, t), param)
                     .Compile().DynamicInvoke(obj) as dynamic;
             }
             catch (TargetInvocationException ex)
             {
                 throw ex.InnerException;
             }
         }
     }
