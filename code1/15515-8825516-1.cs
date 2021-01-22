      .locals init ([0] class [mscorlib]System.Collections.ArrayList _al,
               [1] class [mscorlib]System.Collections.ArrayList _al2)
      IL_0001:  newobj     instance void [mscorlib]System.Collections.ArrayList::.ctor()
      IL_0006:  stloc.0
      IL_0007:  ldtoken    [mscorlib]System.Collections.ArrayList
      IL_000c:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
      IL_0011:  call       object [mscorlib]System.Activator::CreateInstance(class [mscorlib]System.Type)
      IL_0016:  castclass  [mscorlib]System.Collections.ArrayList
      IL_001b:  stloc.1
