    using System.Text;
    using System;
    using System.Runtime.InteropServices;
    namespace Whatever {
        public class GetComposition {
            [DllImport("imm32.dll")]
            public static extern IntPtr ImmGetContext(IntPtr hWnd);
            [DllImport("Imm32.dll")]
            public static extern bool ImmReleaseContext(IntPtr hWnd, IntPtr hIMC);
            [DllImport("Imm32.dll", CharSet = CharSet.Unicode)]
            private static extern int ImmGetCompositionStringW(IntPtr hIMC, int dwIndex, byte[] lpBuf, int dwBufLen);
		
            private const int GCS_COMPSTR = 8;
            /// IntPtr handle is the handle to the textbox
            public string CurrentCompStr(IntPtr handle) {
                int readType = GCS_COMPSTR;
                IntPtr hIMC = ImmGetContext(handle);
				try {
					int strLen = ImmGetCompositionStringW(hIMC, readType, null, 0);
					if (strLen > 0) {
						byte[] buffer = new byte[strLen];
						ImmGetCompositionStringW(hIMC, readType, buffer, strLen);
						return Encoding.Unicode.GetString(buffer);
					} else {
						return string.Empty;
					}
				} finally {
					ImmReleaseContext(handle, hIMC);
				}
            }
        }
    }
