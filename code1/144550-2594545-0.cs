    static T CreateDelegate<T>(this DynamicMethod dm) where T : class
    {
      return dm.CreateDelegate(typeof(T)) as T;
    }
    static Dictionary<Type, Func<object, Dictionary<string, object>>> fieldcache = 
       new Dictionary<Type, Func<object, Dictionary<string, object>>>();
    static Dictionary<string, object> GetFields(object o)
    {
      var t = o.GetType();
      Func<object, Dictionary<string, object>> getter;
      if (!fieldcache.TryGetValue(t, out getter))
      {
        var rettype = typeof(Dictionary<string, object>);
        var dm = new DynamicMethod(t.Name + ":GetFields", rettype, 
           new Type[] { typeof(object) }, t);
        var ilgen = dm.GetILGenerator();
        var instance = ilgen.DeclareLocal(t);
        var dict = ilgen.DeclareLocal(rettype);
        ilgen.Emit(OpCodes.Ldarg_0);
        ilgen.Emit(OpCodes.Castclass, t);
        ilgen.Emit(OpCodes.Stloc, instance);
        ilgen.Emit(OpCodes.Newobj, rettype.GetConstructor(Type.EmptyTypes));
        ilgen.Emit(OpCodes.Stloc, dict);
        var add = rettype.GetMethod("Add");
        foreach (var prop in t.GetProperties(
          BindingFlags.Instance |
          BindingFlags.Public))
        {
          ilgen.Emit(OpCodes.Ldloc, dict);
          
          ilgen.Emit(OpCodes.Ldstr, prop.Name);
          
          ilgen.Emit(OpCodes.Ldloc, instance);
          ilgen.Emit(OpCodes.Ldfld, field);
          ilgen.Emit(OpCodes.Castclass, typeof(object));
          ilgen.Emit(OpCodes.Callvirt, add);
        }
        ilgen.Emit(OpCodes.Ldloc, dict);
        ilgen.Emit(OpCodes.Ret);
        fieldcache[t] = getter = 
          dm.CreateDelegate<Func<object, Dictionary<string, object>>>();
      }
      return getter(o);
    }
