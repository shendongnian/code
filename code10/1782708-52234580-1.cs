	public static class MethodInfoExtensions
	{
		public static void InjectMethod(this MethodInfo target, MethodInfo inject)
		{
			RuntimeHelpers.PrepareMethod(inject.MethodHandle);
			RuntimeHelpers.PrepareMethod(target.MethodHandle);
		
			unsafe
			{
				if (IntPtr.Size == 4)
				{
					int* inj = (int*)inject.MethodHandle.Value.ToPointer() + 2;
					int* tar = (int*)target.MethodHandle.Value.ToPointer() + 2;
		
					if (Debugger.IsAttached)
					{
						byte* injInst = (byte*)*inj;
						byte* tarInst = (byte*)*tar;
		
						int* injSrc = (int*)(injInst + 1);
						int* tarSrc = (int*)(tarInst + 1);
		
						*tarSrc = (((int)injInst + 5) + *injSrc) - ((int)tarInst + 5);
					}
					else
					{
						*tar = *inj;
					}
				}
				else
				{
					long* inj = (long*)inject.MethodHandle.Value.ToPointer() + 1;
					long* tar = (long*)target.MethodHandle.Value.ToPointer() + 1;
		
					if (Debugger.IsAttached)
					{
						byte* injInst = (byte*)*inj;
						byte* tarInst = (byte*)*tar;
		
						int* injSrc = (int*)(injInst + 1);
						int* tarSrc = (int*)(tarInst + 1);
		
						*tarSrc = (((int)injInst + 5) + *injSrc) - ((int)tarInst + 5);
					}
					else
					{
						*tar = *inj;
					}
				}
			}
		}
	}
