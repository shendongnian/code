    class MyRichTextBox : RichTextBox  {
        [DllImport( "user32.dll" )]
        private static extern bool GetScrollInfo( IntPtr hwnd, SBOrientation fnBar,
            ref SCROLLINFO lpsi );
        [StructLayout( LayoutKind.Sequential )]
        private struct SCROLLINFO {
            public uint cbSize;
            public ScrollInfoMask fMask;
            public int nMin;
            public int nMax;
            public uint nPage;
            public int nPos;
            public int nTrackPos;
        }
        private enum ScrollInfoMask : uint {
            SIF_RANGE = 0x1,
            SIF_PAGE = 0x2,
            SIF_POS = 0x4,
            SIF_DISABLENOSCROLL = 0x8,
            SIF_TRACKPOS = 0x10,
            SIF_ALL = ( SIF_RANGE | SIF_PAGE | SIF_POS | SIF_TRACKPOS ),
        }
        private enum SBOrientation : int {
            SB_HORZ = 0x0,
            SB_VERT = 0x1,
        }
        private const int WM_VSCROLL = 0x115;
        private const int SB_LINEUP = 0;
        private const int SB_LINEDOWN = 1;
        private const int SB_PAGEUP = 2;
        private const int SB_PAGEDOWN = 3;
        private const int SB_THUMBPOSITION = 4;
        private const int SB_THUMBTRACK = 5;
        private const int SB_TOP = 6;
        private const int SB_BOTTOM = 7;
        private const int SB_ENDSCROLL = 8;
        private bool isThumbTrack = false;
        private TextBox childTextbox = null;
        private int scrollPos = 0;
        public MyTextBox( TextBox textbox ) { //here you pass the child textbox you want to scroll
            childTextbox = textbox;
        }
        protected override void OnVScroll( EventArgs e ) {
            if( childTextbox == null ) { base.OnVScroll( e ); return; }
            SCROLLINFO si = new Form1.SCROLLINFO();
            si.cbSize = (uint)Marshal.SizeOf( si );
            si.fMask = ScrollInfoMask.SIF_ALL;
            GetScrollInfo( this.Handle, SBOrientation.SB_VERT, ref si );
            //there is a difference when the user uses the thumb to get scroll pos.
            //When user uses the thumb we get *nTrackPos* otherwise *nPos*
            if( isThumbTrack == true ) {
                childTextbox.Location = new Point( childTextbox.Location.X, childTextbox.Location.Y - 
                                                   (si.nTrackPos - scrollPos ) );
                isThumbTrack = false;
                scrollPos = si.nTrackPos;
            }
            else {
                childTextbox.Location = new Point( childTextbox.Location.X, childTextbox.Location.Y -
                                                   ( si.nPos - scrollPos ) );
                scrollPos = si.nPos;
            }
            base.OnVScroll( e );
        }
        protected override void WndProc( ref Message m ) {
            int wParam;
            if(m.Msg == WM_VSCROLL ) {
                wParam = m.WParam.ToInt32();
                wParam &= 0xFFFF; //get low 16 bits of wParam
                
                //Check if user is using the thumb to scroll
                if( wParam == SB_THUMBTRACK ) {
                    isThumbTrack = true;
                }
            }
            base.WndProc( ref m );
        }
    }
