    .method public hidebysig instance void Count() cil managed
    {
        .maxstack 8
        L_0000: ldarg.0 
        L_0001: ldfld class DelegateTest.Program/EventProducer DelegateTest.Program/Counter::producer
        L_0006: ldarg.0 
        L_0007: ldftn instance void DelegateTest.Program/Counter::CountEvent(object, class [mscorlib]System.EventArgs)
        L_000d: newobj instance void [mscorlib]System.EventHandler::.ctor(object, native int)
        L_0012: callvirt instance void DelegateTest.Program/EventProducer::add_EventRaised(class [mscorlib]System.EventHandler)
        L_0017: ldarg.0 
        L_0018: ldfld class DelegateTest.Program/EventProducer DelegateTest.Program/Counter::producer
        L_001d: callvirt instance void DelegateTest.Program/EventProducer::Raise()
        L_0022: ldarg.0 
        L_0023: ldfld class DelegateTest.Program/EventProducer DelegateTest.Program/Counter::producer
        L_0028: ldarg.0 
        L_0029: ldftn instance void DelegateTest.Program/Counter::CountEvent(object, class [mscorlib]System.EventArgs)
        L_002f: newobj instance void [mscorlib]System.EventHandler::.ctor(object, native int)
        L_0034: callvirt instance void DelegateTest.Program/EventProducer::remove_EventRaised(class [mscorlib]System.EventHandler)
        L_0039: ret 
    }
    .method public hidebysig instance void CountWithNew() cil managed
    {
        .maxstack 8
        L_0000: ldarg.0 
        L_0001: ldfld class DelegateTest.Program/EventProducer DelegateTest.Program/Counter::producer
        L_0006: ldarg.0 
        L_0007: ldftn instance void DelegateTest.Program/Counter::CountEvent(object, class [mscorlib]System.EventArgs)
        L_000d: newobj instance void [mscorlib]System.EventHandler::.ctor(object, native int)
        L_0012: callvirt instance void DelegateTest.Program/EventProducer::add_EventRaised(class [mscorlib]System.EventHandler)
        L_0017: ldarg.0 
        L_0018: ldfld class DelegateTest.Program/EventProducer DelegateTest.Program/Counter::producer
        L_001d: callvirt instance void DelegateTest.Program/EventProducer::Raise()
        L_0022: ldarg.0 
        L_0023: ldfld class DelegateTest.Program/EventProducer DelegateTest.Program/Counter::producer
        L_0028: ldarg.0 
        L_0029: ldftn instance void DelegateTest.Program/Counter::CountEvent(object, class [mscorlib]System.EventArgs)
        L_002f: newobj instance void [mscorlib]System.EventHandler::.ctor(object, native int)
        L_0034: callvirt instance void DelegateTest.Program/EventProducer::remove_EventRaised(class [mscorlib]System.EventHandler)
        L_0039: ret 
    }
