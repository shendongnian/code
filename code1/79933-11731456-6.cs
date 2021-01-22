    int[] arr;
    IEnumerator<int> Get1()
    {
        return ((IEnumerable<int>)arr).GetEnumerator();  // <-- 1 non-local call
		
        // ldarg.0 
        // ldfld int32[] foo::arr
        // castclass System.Collections.Generic.IEnumerable`1<int32>
        // callvirt instance class System.Collections.Generic.IEnumerator`1<!0> System.Collections.Generic.IEnumerable`1<int32>::GetEnumerator()
    }
	
    IEnumerator<int> Get2()
    {
        return arr.AsEnumerable().GetEnumerator();   // <-- 2 non-local calls
		
        // ldarg.0 
        // ldfld int32[] foo::arr
        // call class System.Collections.Generic.IEnumerable`1<!!0> System.Linq.Enumerable::AsEnumerable<int32>(class System.Collections.Generic.IEnumerable`1<!!0>)
        // callvirt instance class System.Collections.Generic.IEnumerator`1<!0> System.Collections.Generic.IEnumerable`1<int32>::GetEnumerator()
    }
