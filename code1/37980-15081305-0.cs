    public class CustomTextBox:System.Windows.Forms.TextBox
    {
        [System.Runtime.InteropServices.DllImport("user32")]
        private static extern bool HideCaret(IntPtr hWnd);
        public CustomTextBox()
        {
            TabStop = false;
            MouseDown += new System.Windows.Forms.MouseEventHandler(CustomTextBox_MouseDown);
        }
        void CustomTextBox_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            HideCaret(this.Handle);
        }
    }
