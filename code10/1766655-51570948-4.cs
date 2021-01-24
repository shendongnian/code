	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct TestStruct
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)] public char[] CharArray;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)] public char[] CharArray2;
	}
	
	private void Button1_Click(object sender, RoutedEventArgs e)
	{
		TestStruct _TestStruct = new TestStruct();
	
		IntPtr _IntPtr = Marshal.AllocHGlobal(Marshal.SizeOf(_TestStruct));
	
		_TestStruct.CharArray = "abcd".ToCharArray();
		_TestStruct.CharArray2 = "ab".ToCharArray();
		_TestStruct = (TestStruct)FixArraySizes(_TestStruct); // Due to TestStruct being a struct, we must unbox the result.
		
		Marshal.StructureToPtr(_TestStruct, _IntPtr, false);
	
		// void TestFunction(IntPtr _Intptr);
	
		Marshal.FreeHGlobal(_IntPtr);
	}
	
	private object FixArraySizes(object obj) {
		var objType = obj.GetType();
		var fieldInfos = objType.FindMembers(MemberTypes.Field, BindingFlags.Public | BindingFlags.Instance, (info, _) => ((FieldInfo)info).FieldType == typeof(char[]), null);
		foreach (FieldInfo info in fieldInfos) {
			var fieldValue = (char[])info.GetValue(obj);
			var sizeOfArray = (int?)info.GetCustomAttributesData().FirstOrDefault(attr => attr.AttributeType == typeof(MarshalAsAttribute))?.NamedArguments.FirstOrDefault(arg => arg.MemberName == "SizeConst").TypedValue.Value;
			if (sizeOfArray.HasValue)
			{
				fieldValue = FixArraySize(fieldValue, sizeOfArray.Value);
				info.SetValue(obj, fieldValue);
			}
		}
		
		return obj;
	}
	
	private char[] FixArraySize(char[] array, int expectedSize)
	{
		if (array.Length < expectedSize)
			array = array.Concat(Enumerable.Repeat((char)0, expectedSize - array.Length)).ToArray();
		return array;
	}
