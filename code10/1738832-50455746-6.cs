    public static int A1<T>(T[] array) {
        return array.Length;
    }
    public static int A2(Array array) {
        return array.Length;
    }
    .method public hidebysig static 
        int32 A1<T> (
            !!T[] 'array'
        ) cil managed 
    {
        // Method begins at RVA 0x2050
        // Code size 4 (0x4)
        .maxstack 8
        IL_0000: ldarg.0
        IL_0001: ldlen
        IL_0002: conv.i4
        IL_0003: ret
    } // end of method C::A1
    .method public hidebysig static 
        int32 A2 (
            class [mscorlib]System.Array 'array'
        ) cil managed 
    {
        // Method begins at RVA 0x2055
        // Code size 7 (0x7)
        .maxstack 8
        IL_0000: ldarg.0
        IL_0001: callvirt instance int32 [mscorlib]System.Array::get_Length()
        IL_0006: ret
    } // end of method C::A2
