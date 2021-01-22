    .method private hidebysig static void  IterateOverList(class [mscorlib]System.Collections.Generic.List`1<object> list) cil managed
    {
      // Code size       49 (0x31)
      .maxstack  1
      .locals init (object V_0,
               valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<object> V_1)
      IL_0000:  ldarg.0
      IL_0001:  callvirt   instance valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<!0> class [mscorlib]System.Collections.Generic.List`1<object>::GetEnumerator()
      IL_0006:  stloc.1
      .try
      {
        IL_0007:  br.s       IL_0017
        IL_0009:  ldloca.s   V_1
        IL_000b:  call       instance !0 valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<object>::get_Current()
        IL_0010:  stloc.0
        IL_0011:  ldloc.0
        IL_0012:  call       void [mscorlib]System.Console::WriteLine(object)
        IL_0017:  ldloca.s   V_1
        IL_0019:  call       instance bool valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<object>::MoveNext()
        IL_001e:  brtrue.s   IL_0009
        IL_0020:  leave.s    IL_0030
      }  // end .try
      finally
      {
        IL_0022:  ldloca.s   V_1
        IL_0024:  constrained. valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<object>
        IL_002a:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
        IL_002f:  endfinally
      }  // end handler
      IL_0030:  ret
    } // end of method Test::IterateOverList
