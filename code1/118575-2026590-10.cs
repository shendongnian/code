    // ***** Compiled MSIL CODE ****
    // Notice all fully qualified classes throughout.
    // 
    .class public auto ansi beforefieldinit WebApplication1.process
           extends [System.Web]System.Web.UI.Page
    {
      .field family class [System.Web]System.Web.UI.HtmlControls.HtmlForm form1
      .method family hidebysig instance void 
              Page_Load(object sender,
                        class [mscorlib]System.EventArgs e) cil managed
      {
        // Code size       95 (0x5f)
        .maxstack  4
        .locals init ([0] string strName,
                 [1] string strTime)
        IL_0000:  nop
        IL_0001:  ldarg.0
        IL_0002:  call       instance class [System.Web]System.Web.HttpRequest [System.Web]System.Web.UI.Page::get_Request()
        IL_0007:  ldstr      "name"
        IL_000c:  callvirt   instance string [System.Web]System.Web.HttpRequest::get_Item(string)
