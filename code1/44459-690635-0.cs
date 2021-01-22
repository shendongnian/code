	using System;
	using System.Runtime.InteropServices;
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct UnsafePacket
	{
		int time;
		short id0;
		fixed float acc[3];
		short id1;
		fixed float mat[9];
		public UnsafePacket(byte[] rawData)
		{
			if (rawData == null)
				throw new ArgumentNullException("rawData");
			if (sizeof(byte) * rawData.Length != sizeof(UnsafePacket))
				throw new ArgumentException("rawData");
			fixed (byte* ptr = &rawData[0])
			{
				this = *(UnsafePacket*)rawPtr;
			}
		}
		
		public float GetAcc(int index)
		{
			if (index < 0 || index >= 3)
				throw new ArgumentOutOfRangeException("index");
			fixed (UnsafePacket* ptr = &acc)
			{
				return ptr[index];
			}
		}
		public float GetMat(int index)
		{
			if (index < 0 || index >= 9)
				throw new ArgumentOutOfRangeException("index");
			fixed (UnsafePacket* ptr = &mat)
			{
				return ptr[index];
			}
		}
                
                // etc. for other properties
	}
