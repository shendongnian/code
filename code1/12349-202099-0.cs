    Type GetCodeBehindType()
     { return getCodeBehindTypeRecursive(this.GetType());
     }
  
    Type getCodeBehindTypeRecursive(Type t)
     { var baseType = t.BaseType;
       if (baseType == typeof(BasePage)) return t;
       else return getCodeBehindTypeRecursive(baseType);
     }
