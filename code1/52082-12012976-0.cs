        [DllImport("user32.dll")]
        static extern IntPtr SendMessage
        (
            IntPtr controlHandle,
            uint message,
            IntPtr param1,
            IntPtr param2
        );
        const uint WM_MOUSELEAVE = 0x02A3;
        Point lastMousePoint = Point.Empty;
        void richTextBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (Math.Abs(e.Location.X - lastMousePoint.X) > 1 || Math.Abs(e.Location.Y - lastMousePoint.Y) > 1)
            {
                lastMousePoint = e.Location;
                SendMessage((sender as RichTextBox).Handle, ExensionMethods.WM_MOUSELEAVE, IntPtr.Zero, IntPtr.Zero);
            }
        }
        void richTextBox_MouseHover(object sender, EventArgs e)
        {
            foo();
        }
