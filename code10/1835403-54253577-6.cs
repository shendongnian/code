	internal static class Imports
	{
		[DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true, CharSet = CharSet.Ansi)]
		public static extern IntPtr LoadLibrary([MarshalAs(UnmanagedType.LPStr)]string lpFileName);
		[DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool FreeLibrary(IntPtr hModule);
		[DllImport("user32.dll", CallingConvention = CallingConvention.Winapi)]
		public static extern IntPtr GetDC(IntPtr hWnd);
		[DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr GetProcAddress(IntPtr hModule, [MarshalAs(UnmanagedType.LPStr)]string procName);
	}
	internal sealed class UnmanagedLibrary : IDisposable
	{
		private bool disposed = false;
		public UnmanagedLibrary(string path)
		{
			Handle = Imports.LoadLibrary(path);
			if (Handle == IntPtr.Zero)
			{
				throw new Exception($"Failed to load library \"{path}\" ({Marshal.GetLastWin32Error()}).");
			}
		}
        ~UnmanagedLibrary()
        {
            Dispose(false);
        }
		public void Dispose()
		{ 
			Dispose(true);
			GC.SuppressFinalize(this);           
		}
		private void Dispose(bool disposing)
		{
			if (!disposed)
			{
				Imports.FreeLibrary(Handle);
				
				disposed = true;
			}
		}
		public IntPtr Handle
		{
		    get;
		    private set;
		}
	}
	internal static class OpenGLHelper
	{
		[StructLayout(LayoutKind.Explicit)]
		private struct PIXELFORMATDESCRIPTOR 
		{
			[FieldOffset(0)]
			public UInt16 nSize;
			[FieldOffset(2)]
			public UInt16 nVersion;
			[FieldOffset(4)]
			public UInt32 dwFlags;
			[FieldOffset(8)]
			public Byte iPixelType;
			[FieldOffset(9)]
			public Byte cColorBits;
			[FieldOffset(10)]
			public Byte cRedBits;
			[FieldOffset(11)]
			public Byte cRedShift;
			[FieldOffset(12)]
			public Byte cGreenBits;
			[FieldOffset(13)]
			public Byte cGreenShift;
			[FieldOffset(14)]
			public Byte cBlueBits;
			[FieldOffset(15)]
			public Byte cBlueShift;
			[FieldOffset(16)]
			public Byte cAlphaBits;
			[FieldOffset(17)]
			public Byte cAlphaShift;
			[FieldOffset(18)]
			public Byte cAccumBits;
			[FieldOffset(19)]
			public Byte cAccumRedBits;
			[FieldOffset(20)]
			public Byte cAccumGreenBits;
			[FieldOffset(21)]
			public Byte cAccumBlueBits;
			[FieldOffset(22)]
			public Byte cAccumAlphaBits;
			[FieldOffset(23)]
			public Byte cDepthBits;
			[FieldOffset(24)]
			public Byte cStencilBits;
			[FieldOffset(25)]
			public Byte cAuxBuffers;
			[FieldOffset(26)]
			public SByte iLayerType;
			[FieldOffset(27)]
			public Byte bReserved;
			[FieldOffset(28)]
			public UInt32 dwLayerMask;
			[FieldOffset(32)]
			public UInt32 dwVisibleMask;
			[FieldOffset(36)]
			public UInt32 dwDamageMask;
		}
		private const byte PFD_TYPE_RGBA = 0;
		private const sbyte PFD_MAIN_PLANE = 0;
		private const uint PFD_DOUBLEBUFFER = 1;
		private const uint PFD_DRAW_TO_WINDOW = 4;
		private const uint PFD_SUPPORT_OPENGL = 32;
		private const int GL_VERSION = 0x1F02;
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		private delegate int ChoosePixelFormatDelegate(IntPtr hdc, IntPtr ppfd);
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		private delegate int SetPixelFormatDelegate(IntPtr hdc, int format, IntPtr ppfd);
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		private delegate IntPtr wglCreateContextDelegate(IntPtr arg1);
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		private delegate int wglDeleteContextDelegate(IntPtr arg1);
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		private delegate int wglMakeCurrentDelegate(IntPtr arg1, IntPtr arg2);
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		private delegate IntPtr glGetStringDelegate(int name);
		public static string GetVersion()
		{
			using (UnmanagedLibrary openGLLib = new UnmanagedLibrary("opengl32.dll"))
			using (UnmanagedLibrary gdi32Lib = new UnmanagedLibrary("Gdi32.dll"))
			{
				IntPtr deviceContextHandle = Imports.GetDC(Process.GetCurrentProcess().MainWindowHandle);
				if (deviceContextHandle == IntPtr.Zero)
				{
					throw new Exception("Failed to get device context from the main window.");
				}
				IntPtr choosePixelFormatAddress = Imports.GetProcAddress(gdi32Lib.Handle, "ChoosePixelFormat");
				if (choosePixelFormatAddress == IntPtr.Zero)
				{
					throw new Exception($"Failed to get ChoosePixelFormat address ({Marshal.GetLastWin32Error()}).");
				}
				ChoosePixelFormatDelegate choosePixelFormat = Marshal.GetDelegateForFunctionPointer<ChoosePixelFormatDelegate>(choosePixelFormatAddress);
				PIXELFORMATDESCRIPTOR pfd = new PIXELFORMATDESCRIPTOR
				{
					nSize = (UInt16)Marshal.SizeOf(typeof(PIXELFORMATDESCRIPTOR)),
					nVersion = 1,
					dwFlags = (PFD_DRAW_TO_WINDOW | PFD_SUPPORT_OPENGL | PFD_DOUBLEBUFFER),
					iPixelType = PFD_TYPE_RGBA,
					cColorBits = 32,
					cRedBits = 0,
					cRedShift = 0,
					cGreenBits = 0,
					cGreenShift = 0,
					cBlueBits = 0,
					cBlueShift = 0,
					cAlphaBits = 0,
					cAlphaShift = 0,
					cAccumBits = 0,
					cAccumRedBits = 0,
					cAccumGreenBits = 0,
					cAccumBlueBits = 0,
					cAccumAlphaBits = 0,
					cDepthBits = 24,
					cStencilBits = 8,
					cAuxBuffers = 0,
					iLayerType = PFD_MAIN_PLANE,
					bReserved = 0,
					dwLayerMask = 0,
					dwVisibleMask = 0,
					dwDamageMask = 0
				};
				IntPtr pfdPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(PIXELFORMATDESCRIPTOR)));
				try
				{
					Marshal.StructureToPtr(pfd, pfdPtr, false);
					int pixelFormat = choosePixelFormat(deviceContextHandle, pfdPtr);
					if (pixelFormat == 0)
					{
						throw new Exception($"Failed to choose pixel format ({Marshal.GetLastWin32Error()}).");
					}
					IntPtr setPixelFormatAddress = Imports.GetProcAddress(gdi32Lib.Handle, "SetPixelFormat");
					if (setPixelFormatAddress == IntPtr.Zero)
					{
						throw new Exception($"Failed to get SetPixelFormat address ({Marshal.GetLastWin32Error()}).");
					}
					SetPixelFormatDelegate setPixelFormat = Marshal.GetDelegateForFunctionPointer<SetPixelFormatDelegate>(setPixelFormatAddress);
					if (setPixelFormat(deviceContextHandle, pixelFormat, pfdPtr) <= 0)
					{
						throw new Exception($"Failed to set pixel format ({Marshal.GetLastWin32Error()}).");
					}
					IntPtr wglCreateContextAddress = Imports.GetProcAddress(openGLLib.Handle, "wglCreateContext");
					if (wglCreateContextAddress == IntPtr.Zero)
					{
						throw new Exception($"Failed to get wglCreateContext address ({Marshal.GetLastWin32Error()}).");
					}
					wglCreateContextDelegate wglCreateContext = Marshal.GetDelegateForFunctionPointer<wglCreateContextDelegate>(wglCreateContextAddress);
					IntPtr wglDeleteContextAddress = Imports.GetProcAddress(openGLLib.Handle, "wglDeleteContext");
					if (wglDeleteContextAddress == IntPtr.Zero)
					{
						throw new Exception($"Failed to get wglDeleteContext address ({Marshal.GetLastWin32Error()}).");
					}
					wglDeleteContextDelegate wglDeleteContext = Marshal.GetDelegateForFunctionPointer<wglDeleteContextDelegate>(wglDeleteContextAddress);
					IntPtr openGLRenderingContext = wglCreateContext(deviceContextHandle);
					if (openGLRenderingContext == IntPtr.Zero)
					{
						throw new Exception($"Failed to create OpenGL rendering context ({Marshal.GetLastWin32Error()}).");
					}
					try
					{
						IntPtr wglMakeCurrentAddress = Imports.GetProcAddress(openGLLib.Handle, "wglMakeCurrent");
						if (wglMakeCurrentAddress == IntPtr.Zero)
						{
							throw new Exception($"Failed to get wglMakeCurrent address ({Marshal.GetLastWin32Error()}).");
						}
						wglMakeCurrentDelegate wglMakeCurrent = Marshal.GetDelegateForFunctionPointer<wglMakeCurrentDelegate>(wglMakeCurrentAddress);
						if (wglMakeCurrent(deviceContextHandle, openGLRenderingContext) <= 0)
						{
							throw new Exception($"Failed to make current device context ({Marshal.GetLastWin32Error()}).");
						}
						IntPtr glGetStringAddress = Imports.GetProcAddress(openGLLib.Handle, "glGetString");
						if (glGetStringAddress == IntPtr.Zero)
						{
							throw new Exception($"Failed to get glGetString address ({Marshal.GetLastWin32Error()}).");
						}
						glGetStringDelegate glGetString = Marshal.GetDelegateForFunctionPointer<glGetStringDelegate>(glGetStringAddress);
						IntPtr versionStrPtr = glGetString(GL_VERSION);
						if (versionStrPtr == IntPtr.Zero)
						{
							throw new Exception("Failed to get OpenGL version string.");
						}
						return Marshal.PtrToStringAnsi(versionStrPtr);
					}
					finally
					{
						wglDeleteContext(openGLRenderingContext);
					}
				}
				finally
				{
					Marshal.FreeHGlobal(pfdPtr);
				}
			}
		}
	}
