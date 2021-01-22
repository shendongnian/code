	public static unsafe int RunX86ASM(byte[] asm)
	{
		Func<int> del = () => 0; // create a delegate variable
		Array.Resize(ref asm, asm.Length + 1);
		// add a return instruction at the end to prevent any memory leaks
		asm[asm.Length - 1] = 0xC3;
        fixed (byte* ptr = &asm[0])
        {
        	FieldInfo _methodPtr = typeof(Delegate).GetField("_methodPtr", BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo _methodPtrAux = typeof(Delegate).GetField("_methodPtrAux", BindingFlags.NonPublic | BindingFlags.Instance);
            _methodPtr.SetValue(del, ptr);
            _methodPtrAux.SetValue(del, ptr);
            return del();
        }
	}
