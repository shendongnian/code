        protected override void WndProc(ref Message m)
        {
            const int WM_VSCROLL = 277;
            if (m.Msg == WM_VSCROLL)
            {
                this.Invalidate();
            }
            base.WndProc(ref m);
        }
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            this.Invalidate();
            base.OnMouseWheel(e);
        }
