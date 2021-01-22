    internal class FontHelper
    {
        private delegate int EnumFontFamProc(IntPtr lpelf, IntPtr lpntm, uint FontType, IntPtr lParam);
        private List<string> m_fonts = new List<string>();
        public FontHelper()
        {
            RefreshFontList();
        }
        public void RefreshFontList()
        {
            m_fonts.Clear();
            var dc = GetDC(IntPtr.Zero);
            var d = new EnumFontFamProc(EnumFontCallback);
            var ptr = Marshal.GetFunctionPointerForDelegate(d);
            EnumFontFamilies(dc, null, ptr, IntPtr.Zero);
        }
        public string[] SupportedFonts
        {
            get { return m_fonts.ToArray(); }
        }
        private const int SIZEOF_LOGFONT = 92;
        private const int LOGFONT = 28;
        private const int LF_FACESIZE = 32;
        private const int LF_FULLFACESIZE = 64;
        [DllImport("coredll", SetLastError = true)]
        private static extern IntPtr GetDC(IntPtr hwnd);
        [DllImport("coredll", SetLastError = true)]
        private static extern int EnumFontFamilies(IntPtr hdc, string lpszFamily, IntPtr lpEnumFontFamProc, IntPtr lParam);
        private int EnumFontCallback(IntPtr lpelf, IntPtr lpntm, uint FontType, IntPtr lParam)
        {
            var data = new byte[SIZEOF_LOGFONT + LF_FACESIZE + LF_FULLFACESIZE];
            Marshal.Copy(lpelf, data, 0, data.Length);
            var fontName = Encoding.Unicode.GetString(data, SIZEOF_LOGFONT, LF_FULLFACESIZE).TrimEnd('\0');
            Debug.WriteLine(fontName);
            m_fonts.Add(fontName);
            return 1;
        }
    }
