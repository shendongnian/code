     [DllImport("user32", CharSet = CharSet.Auto)]
        private static extern int SystemParametersInfo(int uAction, int uParam, ref NONCLIENTMETRICS lpvParam, int fuWinIni);
    
        private const int LF_FACESIZE = 32;
    
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private struct LOGFONT
        {
            public int lfHeight;
            public int lfWidth;
            public int lfEscapement;
            public int lfOrientation;
            public int lfWeight;
            public byte lfItalic;
            public byte lfUnderline;
            public byte lfStrikeOut;
            public byte lfCharSet;
            public byte lfOutPrecision;
            public byte lfClipPrecision;
            public byte lfQuality;
            public byte lfPitchAndFamily;
    
            /// <summary>
            /// <see cref="UnmanagedType.ByValTStr"/> means that the string
            /// should be marshalled as an array of TCHAR embedded in the
            /// structure.  This implies that the font names can be no larger
            /// than <see cref="LF_FACESIZE"/> including the terminating '\0'.
            /// That works out to 31 characters.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = LF_FACESIZE)]
            public string lfFaceName;
    
            // to shut it up about the warnings
            public LOGFONT(string lfFaceName)
            {
                this.lfFaceName = lfFaceName;
                lfHeight = lfWidth = lfEscapement = lfOrientation = lfWeight = 0;
                lfItalic = lfUnderline = lfStrikeOut = lfCharSet = lfOutPrecision
                = lfClipPrecision = lfQuality = lfPitchAndFamily = 0;
            }
        }
    
        private struct NONCLIENTMETRICS
        {
            public int cbSize;
            public int iBorderWidth;
            public int iScrollWidth;
            public int iScrollHeight;
            public int iCaptionWidth;
            public int iCaptionHeight;
            /// <summary>
            /// Since <see cref="LOGFONT"/> is a struct instead of a class,
            /// we don't have to do any special marshalling here.  Much
            /// simpler this way.
            /// </summary>
            public LOGFONT lfCaptionFont;
            public int iSMCaptionWidth;
            public int iSMCaptionHeight;
            public LOGFONT lfSMCaptionFont;
            public int iMenuWidth;
            public int iMenuHeight;
            public LOGFONT lfMenuFont;
            public LOGFONT lfStatusFont;
            public LOGFONT lfMessageFont;
        }
    
        private const int SPI_GETNONCLIENTMETRICS = 41;
        private const int SPI_SETNONCLIENTMETRICS = 42;
        private const int SPIF_SENDCHANGE = 2;
