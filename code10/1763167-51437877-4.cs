    .method public hidebysig 
        instance class TestDelegate BuildInstanceMethodDelegate () cil managed 
    {
        // Method begins at RVA 0x2052
        // Code size 13 (0xd)
        .maxstack 8
        IL_0000: ldarg.0
        IL_0001: ldftn instance void C::InstanceMethod()
        IL_0007: newobj instance void TestDelegate::.ctor(object, native int)
    .method public hidebysig 
        instance class TestDelegate BuildStaticMethodDelegate () cil managed 
    {
        // Method begins at RVA 0x2060
        // Code size 13 (0xd)
        .maxstack 8
        IL_0000: ldnull
        IL_0001: ldftn void C::StaticMethod()
        IL_0007: newobj instance void TestDelegate::.ctor(object, native int)
