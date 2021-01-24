    class MyRichTextBox : RichTextBox  {
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
            //there is a difference when the user uses the thumb to get scroll pos
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
                if( wParam == SB_THUMBTRACK ) {
                    isThumbTrack = true;
                }
            }
            base.WndProc( ref m );
        }
    }
