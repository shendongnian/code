    using System;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
<!--->
    public class MyTextBox : TextBox
    {
        private const int WM_PASTE = 0x0302;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool MessageBeep(int type);
        protected override void WndProc(ref Message m)
        {
            if (m.Msg != WM_PASTE) { base.WndProc(ref m); }
            else
            {
                var text = SanitizeText(Clipboard.GetText());
                SelectedText = text;
            }
        }
        protected virtual string SanitizeText(string value)
        {
            return Regex.Replace(value ?? "", @"[^a-zA-Z0-9_]", "");
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            var input = e.KeyChar;
            var allowedChars = new char[] { '_', '\b' };
            if (((ModifierKeys & (Keys.Control | Keys.Alt)) != 0) |
                Char.IsLetterOrDigit(e.KeyChar) |
                allowedChars.Contains(input))
            {
                base.OnKeyPress(e);
            }
            else
            {
                e.Handled = true;
                MessageBeep(0);
            }
        }
    }
