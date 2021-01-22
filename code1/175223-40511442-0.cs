    		public static unsafe void ChangeCharInString(ref string str, char c, int index)
			{
				GCHandle handle;
				try
				{
					handle = GCHandle.Alloc(str, GCHandleType.Pinned);
					char* ptr = (char*)handle.AddrOfPinnedObject();
					ptr[index] = c;
				}
				finally
				{
					try
					{
						handle.Free();
					}
					catch(InvalidOperationException)
					{
					}
				}
			}
