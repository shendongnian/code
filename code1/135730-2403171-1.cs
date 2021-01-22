    .method family hidebysig instance void Page_Load(object sender, class [mscorlib]System.EventArgs e) cil managed
    {
        .maxstack 8
        L_0000: nop 
        L_0001: ldarg.0 
        L_0002: call instance class [System.Web]System.Web.HttpApplicationState [System.Web]System.Web.UI.Page::get_Application()
        L_0007: ldstr "Key"
        L_000c: ldc.i4.8 
        L_000d: box int32
        L_0012: callvirt instance void [System.Web]System.Web.HttpApplicationState::set_Item(string, object)
        L_0017: nop 
        L_0018: ldarg.0 
        L_0019: call instance class [System.Web]System.Web.HttpApplicationState [System.Web]System.Web.UI.Page::get_Application()
        L_001e: callvirt instance class [System.Web]System.Web.HttpApplicationState [System.Web]System.Web.HttpApplicationState::get_Contents()
        L_0023: ldstr "Key"
        L_0028: ldc.i4.8 
        L_0029: box int32
        L_002e: callvirt instance void [System.Web]System.Web.HttpApplicationState::set_Item(string, object)
        L_0033: nop 
        L_0034: ret 
    }
