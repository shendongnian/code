    //using System;
    //using System.Linq.Expressions;
    //using System.Reflection;
    public static object Cast(object obj, Type t)
    { 
        try
        {
            var param = Expression.Parameter(obj.GetType());
            return Expression.Lambda(Expression.Convert(param, t), param)
                     .Compile().DynamicInvoke(obj);
        }
        catch (TargetInvocationException ex)
        {
             throw ex.InnerException;
        }         
    }
Please note, that this only performs casting on the data and the underlying type. The return value is still object, and has to be used as: dynamic d = Cast(obj, t);, because the compiler still cannot know its actual type.
