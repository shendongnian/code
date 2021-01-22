    IEnumerator<int> NoGet()                    // error - do not use
    {
        return (IEnumerator<int>)arr.GetEnumerator();
		
        // ldarg.0 
        // ldfld int32[] foo::arr
        // callvirt instance class System.Collections.IEnumerator System.Array::GetEnumerator()
        // castclass System.Collections.Generic.IEnumerator`1<int32>
    }
