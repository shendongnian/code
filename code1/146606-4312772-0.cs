     public T Cast<T>(object obj)
     {
          return (T) obj;
     }
    
     string sTypename = "SomeClassName"; 
     MethodInfo cast = this.GetType().GetMethod("Cast");
     MethodInfo genericCast = cast.MakeGenericMethod(new Type[] { Type.GetType(sTypename) });
     Object castedValue = genericCast.Invoke(this, new object[] { instanceToBeCasted });
    
    
