	[ComImport, Guid("75A67021-058A-4E2A-8686-52181AAF600A"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IInterface
	{
		[return: MarshalAs(UnmanagedType.Struct)]
		object getAttribute([In, MarshalAs(UnmanagedType.BStr)] string strAttributeName);
	}
	private delegate int IInterface_getAttribute(
		IntPtr pInterface,
		[MarshalAs(UnmanagedType.BStr)] string name,
		IntPtr result);
	public static object getAttribute(this IInterface obj, string name)
	{
		var ifaceType = typeof(IInterface);
		var ifaceMethodInfo = ((Func<string, object>)obj.getAttribute).Method;
		var slot = Marshal.GetComSlotForMethodInfo(ifaceMethodInfo);
		var ifacePtr = Marshal.GetComInterfaceForObject(obj, ifaceType);
		try
		{
			var vtablePtr = Marshal.ReadIntPtr(ifacePtr);
			var methodPtr = Marshal.ReadIntPtr(vtablePtr, IntPtr.Size * slot);
			var methodWrapper = Marshal.GetDelegateForFunctionPointer<IInterface_getAttribute>(methodPtr);
			var resultVar = new VariantClass();
			var resultHandle = GCHandle.Alloc(resultVar, GCHandleType.Pinned);
			try
			{
				var pResultVar = resultHandle.AddrOfPinnedObject();
				VariantInit(pResultVar);
				var hr = methodWrapper(ifacePtr, name, pResultVar);
				if (hr < 0)
				{
					Marshal.ThrowExceptionForHR(hr);
				}
				if (resultVar.vt == VT_PTR)
				{
					return resultVar.ptr;
				}
				try
				{
					return Marshal.GetObjectForNativeVariant(pResultVar);
				}
				finally
				{
					VariantClear(pResultVar);
				}
			}
			finally
			{
				resultHandle.Free();
			}
		}
		finally
		{
			Marshal.Release(ifacePtr);
		}
	}
