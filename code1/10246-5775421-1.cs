    .method public hidebysig static int32  Count<TSource>(class 
    [mscorlib]System.Collections.Generic.IEnumerable`1<!!TSource> source) cil managed
    {
      .custom instance void System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
      // Code size       85 (0x55)
      .maxstack  2
      .locals init (class [mscorlib]System.Collections.Generic.ICollection`1<!!TSource> V_0,
               class [mscorlib]System.Collections.ICollection V_1,
               int32 V_2,
               class [mscorlib]System.Collections.Generic.IEnumerator`1<!!TSource> V_3)
      IL_0000:  ldarg.0
      IL_0001:  brtrue.s   IL_000e
      IL_0003:  ldstr      "source"
      IL_0008:  call       class [mscorlib]System.Exception System.Linq.Error::ArgumentNull(string)
      IL_000d:  throw
      IL_000e:  ldarg.0
      IL_000f:  isinst     class [mscorlib]System.Collections.Generic.ICollection`1<!!TSource>
      IL_0014:  stloc.0
      IL_0015:  ldloc.0
      IL_0016:  brfalse.s  IL_001f
      IL_0018:  ldloc.0
      IL_0019:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.ICollection`1<!!TSource>::get_Count()
      IL_001e:  ret
      IL_001f:  ldarg.0
      IL_0020:  isinst     [mscorlib]System.Collections.ICollection
      IL_0025:  stloc.1
      IL_0026:  ldloc.1
      IL_0027:  brfalse.s  IL_0030
      IL_0029:  ldloc.1
      IL_002a:  callvirt   instance int32 [mscorlib]System.Collections.ICollection::get_Count()
      IL_002f:  ret
      IL_0030:  ldc.i4.0
      IL_0031:  stloc.2
      IL_0032:  ldarg.0
      IL_0033:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class [mscorlib]System.Collections.Generic.IEnumerable`1<!!TSource>::GetEnumerator()
      IL_0038:  stloc.3
      .try
      {
        IL_0039:  br.s       IL_003f
        IL_003b:  ldloc.2
        IL_003c:  ldc.i4.1
        IL_003d:  add.ovf
        IL_003e:  stloc.2
        IL_003f:  ldloc.3
        IL_0040:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
        IL_0045:  brtrue.s   IL_003b
        IL_0047:  leave.s    IL_0053
      }  // end .try
      finally
      {
        IL_0049:  ldloc.3
        IL_004a:  brfalse.s  IL_0052
        IL_004c:  ldloc.3
        IL_004d:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
        IL_0052:  endfinally
      }  // end handler
      IL_0053:  ldloc.2
      IL_0054:  ret
    } // end of method Enumerable::Count
