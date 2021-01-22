    .class private auto ansi B
        extends [mscorlib]System.Object
    {
        .method private hidebysig specialname rtspecialname static void .cctor() cil managed
        {
            .maxstack 8
            L_0000: nop 
            L_0001: ldsfld class [mscorlib]System.Collections.Generic.Dictionary`2<string, class Connection> WebConfigurationManager::ConnectionStrings
            L_0006: ldstr "SomeConnection"
            L_000b: callvirt instance !1 [mscorlib]System.Collections.Generic.Dictionary`2<string, class Connection>::get_Item(!0)
            L_0010: ldfld string Connection::ConnectionString
            L_0015: stsfld string B::connectionString
            L_001a: ret 
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
    
