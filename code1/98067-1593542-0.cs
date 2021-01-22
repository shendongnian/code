    var asm = Assembly.Load(assemblyName);
    var t = asm.GetType(typeName);
    // Pass array of parameter types to resolve between overloads (here no arguments).
    var m = t.GetMathod(methodName, BindingFlags.Static, null, new Type[] {}, null);
    // Pass no "this" or arguments.
    var res = (resultType) m.Invoke(null, null);
