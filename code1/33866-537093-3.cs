    .method public hidebysig instance void test_lambda() cil managed
    {
        .maxstack 8
        L_0000: ldarg.0 
        L_0001: ldfld class [mscorlib]System.Collections.Generic.List`1<string> Class1::list
        L_0006: ldsfld class [System.Core]System.Func`2<string, bool> Class1::CS$<>9__CachedAnonymousMethodDelegate1
        L_000b: brtrue.s L_001e
        L_000d: ldnull 
        L_000e: ldftn bool Class1::<test_lambda>b__0(string)
        L_0014: newobj instance void [System.Core]System.Func`2<string, bool>::.ctor(object, native int)
        L_0019: stsfld class [System.Core]System.Func`2<string, bool> Class1::CS$<>9__CachedAnonymousMethodDelegate1
        L_001e: ldsfld class [System.Core]System.Func`2<string, bool> Class1::CS$<>9__CachedAnonymousMethodDelegate1
        L_0023: call class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0> [System.Core]System.Linq.Enumerable::Where<string>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>, class [System.Core]System.Func`2<!!0, bool>)
        L_0028: pop 
        L_0029: ret 
    }
    .method public hidebysig instance void test_linq() cil managed
    {
        .maxstack 8
        L_0000: ldarg.0 
        L_0001: ldfld class [mscorlib]System.Collections.Generic.List`1<string> Class1::list
        L_0006: ldsfld class [System.Core]System.Func`2<string, bool> Class1::CS$<>9__CachedAnonymousMethodDelegate3
        L_000b: brtrue.s L_001e
        L_000d: ldnull 
        L_000e: ldftn bool Class1::<test_linq>b__2(string)
        L_0014: newobj instance void [System.Core]System.Func`2<string, bool>::.ctor(object, native int)
        L_0019: stsfld class [System.Core]System.Func`2<string, bool> Class1::CS$<>9__CachedAnonymousMethodDelegate3
        L_001e: ldsfld class [System.Core]System.Func`2<string, bool> Class1::CS$<>9__CachedAnonymousMethodDelegate3
        L_0023: call class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0> [System.Core]System.Linq.Enumerable::Where<string>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>, class [System.Core]System.Func`2<!!0, bool>)
        L_0028: pop 
        L_0029: ret 
    }
