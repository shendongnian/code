    namespace NativeInterop {
        using System.Runtime.InteropServices;
        public static partial class User32 {
            private const string DLL_NAME = "user32.dll";
            [StructLayout(LayoutKind.Sequential)]
            private struct RECT {
                int left, top, right, bottom;
                public Rectangle ToRectangle() {
                    return new Rectangle(left, top, right - left, bottom - top);
                }
            }
            [DllImport(DLL_NAME, SetLastError = true)]
            public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, String className, String windowTitle);
            [DllImport(DLL_NAME)]
            private static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);
            public static Rectangle GetClientRect(IntPtr hWnd) {
                var nativeRect = new RECT();
                GetClientRect(hWnd, out nativeRect);
                return nativeRect.ToRectangle();
            }
        }
    }
