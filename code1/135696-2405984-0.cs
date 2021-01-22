        public void ScrollTo(int Position)
        {
            SetScrollPos((IntPtr)this.Handle, 0x1, Position, true);
            PostMessageA((IntPtr)this.Handle, 0x115, 4 + 0x10000 * Position, 0);
        }
