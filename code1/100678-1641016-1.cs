    // Equality operator. Returns dbNull if either operand is dbNull, 
       // otherwise returns dbTrue or dbFalse:
       public static DBBool operator ==(DBBool x, DBBool y) 
       {
          if (x.value == 0 || y.value == 0) return dbNull;
          return x.value == y.value? dbTrue: dbFalse;
       }
    
       // Inequality operator. Returns dbNull if either operand is
       // dbNull, otherwise returns dbTrue or dbFalse:
       public static DBBool operator !=(DBBool x, DBBool y) 
       {
          if (x.value == 0 || y.value == 0) return dbNull;
          return x.value != y.value? dbTrue: dbFalse;
       }
