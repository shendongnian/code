    t.GetProperties().Where(p => 
        (p.GetGetMethod() ?? p.GetSetMethod()).IsDefined(typeof(CompilerGeneratedAttribute), false))
       .Select(p => new 
       { 
          Property = p, 
          Field = t.GetField(string.Format("<{0}>k__BackingField", p.Name),
              System.Reflection.BindingFlags.NonPublic | 
              System.Reflection.BindingFlags.Instance) 
       });
