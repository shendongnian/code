        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left; // X coordinate of topleft point
            public int Top; // Y coordinate of topleft point
            public int Right; // X coordinate of bottomright point
            public int Bottom; // Y coordinate of bottomright point
        }
