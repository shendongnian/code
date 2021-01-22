    public T LoadDefaultForType<T>()
    {
      try
      {
        string interfaceName = typeof(T).FullName;
        // Assumes that class has same name as interface, without leading I, and
        // is in ..."Classes" namespace instead of ..."Interfaces"
        string className = interfaceName.Replace("Interfaces.I", "Classes.");
        Type t = Type.GetType(className, true, true);
        System.Reflection.ConstructorInfo info = t.GetConstructor(Type.EmptyTypes);
        return (T)(info.Invoke(null));
      }
      catch
      {
        throw new NotSupportException("Give me something I can work with!");
      }
    }
Note that - as written - it won't work across assembly boundaries.  It can be done using essentially the same code, however - you just need to supply the assembly-qualified name to the Type.GetType() method.
