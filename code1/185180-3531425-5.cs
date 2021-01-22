	.method public hidebysig specialname instance bool get_Visible1() cil managed
	{
	    .maxstack 2
	    .locals init (
		[0] bool b)
	    L_0000: call class [System.Web]System.Web.HttpContext [System.Web]System.Web.HttpContext::get_Current()
	    L_0005: callvirt instance class [System.Web]System.Web.HttpRequest [System.Web]System.Web.HttpContext::get_Request()
	    L_000a: ldstr "visible"
	    L_000f: callvirt instance string [System.Web]System.Web.HttpRequest::get_Item(string)
	    L_0014: ldloca.s b
	    L_0016: call bool [mscorlib]System.Boolean::TryParse(string, bool&)
	    L_001b: brfalse.s L_001f
	    L_001d: ldloc.0 
	    L_001e: ret 
	    L_001f: ldc.i4.0 
	    L_0020: ret 
	}
	.method public hidebysig specialname instance bool get_Visible2() cil managed
	{
	    .maxstack 2
	    .locals init (
		[0] bool b)
	    L_0000: call class [System.Web]System.Web.HttpContext [System.Web]System.Web.HttpContext::get_Current()
	    L_0005: callvirt instance class [System.Web]System.Web.HttpRequest [System.Web]System.Web.HttpContext::get_Request()
	    L_000a: ldstr "visible"
	    L_000f: callvirt instance string [System.Web]System.Web.HttpRequest::get_Item(string)
	    L_0014: ldloca.s b
	    L_0016: call bool [mscorlib]System.Boolean::TryParse(string, bool&)
	    L_001b: brtrue.s L_001f
	    L_001d: ldc.i4.0 
	    L_001e: ret 
	    L_001f: ldloc.0 
	    L_0020: ret 
	}
	.method public hidebysig specialname instance bool get_Visible3() cil managed
	{
	    .maxstack 2
	    .locals init (
		[0] bool b)
	    L_0000: call class [System.Web]System.Web.HttpContext [System.Web]System.Web.HttpContext::get_Current()
	    L_0005: callvirt instance class [System.Web]System.Web.HttpRequest [System.Web]System.Web.HttpContext::get_Request()
	    L_000a: ldstr "visible"
	    L_000f: callvirt instance string [System.Web]System.Web.HttpRequest::get_Item(string)
	    L_0014: ldloca.s b
	    L_0016: call bool [mscorlib]System.Boolean::TryParse(string, bool&)
	    L_001b: pop 
	    L_001c: ldloc.0 
	    L_001d: ret 
	}
