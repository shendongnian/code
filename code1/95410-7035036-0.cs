	public class SafeHBitmapHandle : SafeHandleZeroOrMinusOneIsInvalid
	{
		[SecurityCritical]
		public SafeHBitmapHandle(IntPtr preexistingHandle, bool ownsHandle)
			: base(ownsHandle)
		{
			SetHandle(preexistingHandle);
		}
		protected override bool ReleaseHandle()
		{
			return GdiNative.DeleteObject(handle) > 0;
		}
	}
