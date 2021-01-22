    int[] arr;
    IEnumerator<int> Get1()
    {
        return ((IEnumerable<int>)arr).GetEnumerator();
        // L_0001: ldarg.0 
        // L_0002: ldfld int32[] agree.foo::arr
        // L_0007: castclass [mscorlib]System.Collections.Generic.IEnumerable`1<int32>
        // L_000c: callvirt instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> [mscorlib]System.Collections.Generic.IEnumerable`1<int32>::GetEnumerator()
        // L_0011: stloc.0 
    }
    IEnumerator<int> Get2()
    {
        return arr.AsEnumerable().GetEnumerator();
        // L_0001: ldarg.0 
        // L_0002: ldfld int32[] agree.foo::arr
        // L_0007: call class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0> [System.Core]System.Linq.Enumerable::AsEnumerable<int32>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>)
        // L_000c: callvirt instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> [mscorlib]System.Collections.Generic.IEnumerable`1<int32>::GetEnumerator()
        // L_0011: stloc.0 
    }
