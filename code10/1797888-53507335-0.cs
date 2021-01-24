	internal static IntPtr javaClassHandle;
	internal static IntPtr classRef
	{
		get
		{
			return JNIEnv.FindClass("io/fotoapparat/preview/Frame", ref javaClassHandle);
		}
	}
	static IntPtr imageJFieldId;
	
	public void ProcessFrame(Frame frame)
	{            
		int bufferSize = frame.Image.Count;
		var buffer = new byte[bufferSize];
		if (imageJFieldId == IntPtr.Zero)
			imageJFieldId = JNIEnv.GetFieldID(classRef, "image", "[B");
		var fieldObject = JNIEnv.GetObjectField(frame.Handle, imageJFieldId);
		var fastByteArray = new FastJavaByteArray(fieldObject);
		fastByteArray.CopyTo(buffer, 0);
	}
