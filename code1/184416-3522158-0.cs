        protected override CreateParams CreateParams
        {
            get
            {
                var p = base.CreateParams;
                p.Style |= NativeMethods.WindowStyles.WS_BORDER;
                p.Style |= NativeMethods.WindowStyles.WS_HSCROLL;
                p.Style |= NativeMethods.WindowStyles.WS_VSCROLL;
                return p;
            }
        }
        private Point ScrollPosition
        {
            get
            {
                var info = new NativeMethods.ScrollInfo();
                info.cbSize = (uint)Marshal.SizeOf(info);
                info.fMask = NativeMethods.ScrollInfoMask.SIF_POS;
                NativeMethods.GetScrollInfo(this.Handle, NativeMethods.SBFlags.SB_HORZ, out info);
                int x = info.nPos;
                NativeMethods.GetScrollInfo(this.Handle, NativeMethods.SBFlags.SB_VERT, out info);
                int y = info.nPos;
                return new Point(x, y);
            }
            set
            {
                var info = new NativeMethods.ScrollInfo();
                info.cbSize = (uint)Marshal.SizeOf(info);
                info.fMask = NativeMethods.ScrollInfoMask.SIF_POS;
                info.nPos = value.X;
                NativeMethods.SetScrollInfo(this.Handle, NativeMethods.SBFlags.SB_HORZ, ref info, true);
                info.nPos = value.Y;
                NativeMethods.SetScrollInfo(this.Handle, NativeMethods.SBFlags.SB_VERT, ref info, true);
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            // Clear the background color.
            e.Graphics.Clear(Color.White);
            e.Graphics.Transform = this.TransformMatrix.Clone();
            // Do drawing here.
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Do nothing.
        }
        private void OnScroll(ScrollEventArgs se)
        {
            float offset = se.NewValue - se.OldValue;
            if (se.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                this.TransformMatrix.Translate(-offset, 0);
            }
            else
            {
                this.TransformMatrix.Translate(0, -offset);
            }
            this.Refresh();
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case NativeMethods.WindowMessages.WM_HSCROLL:
                case NativeMethods.WindowMessages.WM_VSCROLL:
                    this.WmScroll(ref m);
                    m.Result = IntPtr.Zero;
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        private void WmScroll(ref Message m)
        {
            int smallChange = 20;
            uint sb = NativeMethods.SBFlags.SB_HORZ;
            var orientation = ScrollOrientation.HorizontalScroll;
            
            if(m.Msg == NativeMethods.WindowMessages.WM_VSCROLL)
            {
                sb = NativeMethods.SBFlags.SB_VERT;
                orientation = ScrollOrientation.VerticalScroll;
            }
            // Get current scroll Page and Range.
            var info = new NativeMethods.ScrollInfo();
            info.cbSize = (uint)Marshal.SizeOf(info);
            info.fMask = NativeMethods.ScrollInfoMask.SIF_PAGE | NativeMethods.ScrollInfoMask.SIF_POS;
            NativeMethods.GetScrollInfo(this.Handle, sb, out info);
            int newValue = info.nPos;
            var type = ScrollEventType.SmallDecrement;
            switch (Unmanaged.LoWord(m.WParam))
            {
                case NativeMethods.SBCommands.SB_BOTTOM:
                    type = ScrollEventType.Last;
                    break;
                case NativeMethods.SBCommands.SB_ENDSCROLL:
                    type = ScrollEventType.EndScroll;
                    break;
                case NativeMethods.SBCommands.SB_LINEDOWN:
                    newValue += smallChange;
                    type = ScrollEventType.SmallIncrement;
                    break;
                case NativeMethods.SBCommands.SB_LINEUP:
                    newValue -= smallChange;
                    type = ScrollEventType.SmallDecrement;
                    break;
                case NativeMethods.SBCommands.SB_PAGEDOWN:
                    newValue += (int)info.nPage;
                    type = ScrollEventType.LargeIncrement;
                    break;
                case NativeMethods.SBCommands.SB_PAGEUP:
                    newValue -= (int)info.nPage;
                    type = ScrollEventType.LargeDecrement;
                    break;
                case NativeMethods.SBCommands.SB_THUMBPOSITION:
                    type = ScrollEventType.ThumbPosition;
                    break;
                case NativeMethods.SBCommands.SB_THUMBTRACK:
                    newValue = Unmanaged.HiWord(m.WParam);
                    type = ScrollEventType.ThumbTrack;
                    break;
                case NativeMethods.SBCommands.SB_TOP:
                    type = ScrollEventType.First;
                    break;
            }
            var newInfo = new NativeMethods.ScrollInfo();
            newInfo.cbSize = (uint)Marshal.SizeOf(newInfo);
            newInfo.fMask = NativeMethods.ScrollInfoMask.SIF_POS;
            newInfo.nPos = newValue;
            
            NativeMethods.SetScrollInfo(this.Handle, sb, ref newInfo, false);
            
            int realNewValue = (orientation == ScrollOrientation.HorizontalScroll) ? this.ScrollPosition.X : this.ScrollPosition.Y;
            // Fire the scroll event.
            // TODO - Create a Scroll event.
            this.OnScroll(new ScrollEventArgs(type, info.nPos, realNewValue, orientation));
        }
