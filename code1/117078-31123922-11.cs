	Offset	OpCode	Operand
	0	ldsfld	System.Runtime.CompilerServices.CallSite`1<System.Func`3<System.Runtime.CompilerServices.CallSite,System.Object,System.Object[]>> TestApp.Program/<UnreachableCodeTest>o__SiteContainere6::<>p__Sitee7
	5	brtrue.s	-> (10) ldsfld System.Runtime.CompilerServices.CallSite`1<System.Func`3<System.Runtime.CompilerServices.CallSite,System.Object,System.Object[]>> TestApp.Program/<UnreachableCodeTest>o__SiteContainere6::<>p__Sitee7
	7	ldc.i4.0	
	8	ldtoken	System.Object[]
	13	call	System.Type System.Type::GetTypeFromHandle(System.RuntimeTypeHandle)
	18	ldtoken	TestApp.Program
	23	call	System.Type System.Type::GetTypeFromHandle(System.RuntimeTypeHandle)
	28	call	System.Runtime.CompilerServices.CallSiteBinder Microsoft.CSharp.RuntimeBinder.Binder::Convert(Microsoft.CSharp.RuntimeBinder.CSharpBinderFlags,System.Type,System.Type)
	33	call	System.Runtime.CompilerServices.CallSite`1<!0> System.Runtime.CompilerServices.CallSite`1<System.Func`3<System.Runtime.CompilerServices.CallSite,System.Object,System.Object[]>>::Create(System.Runtime.CompilerServices.CallSiteBinder)
	38	stsfld	System.Runtime.CompilerServices.CallSite`1<System.Func`3<System.Runtime.CompilerServices.CallSite,System.Object,System.Object[]>> TestApp.Program/<UnreachableCodeTest>o__SiteContainere6::<>p__Sitee7
	43	ldsfld	System.Runtime.CompilerServices.CallSite`1<System.Func`3<System.Runtime.CompilerServices.CallSite,System.Object,System.Object[]>> TestApp.Program/<UnreachableCodeTest>o__SiteContainere6::<>p__Sitee7
	48	ldfld	!0 System.Runtime.CompilerServices.CallSite`1<System.Func`3<System.Runtime.CompilerServices.CallSite,System.Object,System.Object[]>>::Target
	53	ldsfld	System.Runtime.CompilerServices.CallSite`1<System.Func`3<System.Runtime.CompilerServices.CallSite,System.Object,System.Object[]>> TestApp.Program/<UnreachableCodeTest>o__SiteContainere6::<>p__Sitee7
	58	call	System.Object TestApp.Unreachable::Code()
	63	callvirt	!2 System.Func`3<System.Runtime.CompilerServices.CallSite,System.Object,System.Object[]>::Invoke(!0,!1)
	68	ret	
