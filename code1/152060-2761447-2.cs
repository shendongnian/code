    .class private auto ansi beforefieldinit A
        extends [mscorlib]System.Object
    {
        .method private hidebysig specialname rtspecialname static void .cctor() cil managed
        {
            .maxstack 8
            L_0000: ldsfld class [mscorlib]System.Collections.Generic.Dictionary`2<string, class Connection> WebConfigurationManager::ConnectionStrings
            L_0005: ldstr "SomeConnection"
            L_000a: callvirt instance !1 [mscorlib]System.Collections.Generic.Dictionary`2<string, class Connection>::get_Item(!0)
            L_000f: ldfld string Connection::ConnectionString
            L_0014: stsfld string A::connectionString
            L_0019: ret 
        }
    
        .method public hidebysig specialname rtspecialname instance void .ctor() cil managed
        {
            .maxstack 8
            L_0000: ldarg.0 
            L_0001: call instance void [mscorlib]System.Object::.ctor()
            L_0006: ret 
        }
    
        .field private static initonly string connectionString
    } 
