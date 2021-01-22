    .method private hidebysig static 
    	void Main (
    		string[] args
    	) cil managed 
    {
    	// Method begins at RVA 0x2050
    	// Code size 27 (0x1b)
    	.maxstack 1
    	.entrypoint
    	.locals init (
    		[0] class [mscorlib]System.Collections.Generic.List`1<int32> testList,
    		[1] class [mscorlib]System.Collections.Generic.IEnumerator`1<int32> enumAsInterface,
    		[2] valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<int32> enumAsStruct
    	)
    
    	IL_0000: nop
    	IL_0001: newobj instance void class [mscorlib]System.Collections.Generic.List`1<int32>::.ctor()
    	IL_0006: stloc.0
    	IL_0007: ldloc.0
    	IL_0008: callvirt instance valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<!0> class [mscorlib]System.Collections.Generic.List`1<int32>::GetEnumerator()
    	IL_000d: box valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<int32>
    	IL_0012: stloc.1
    	IL_0013: ldloc.0
    	IL_0014: callvirt instance valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<!0> class [mscorlib]System.Collections.Generic.List`1<int32>::GetEnumerator()
    	IL_0019: stloc.2
    	IL_001a: ret
    } // end of method Program::Main
