    using System;
    using System.Windows.Forms;
    public class ClipboardEventArgs : EventArgs
    {
        public string ClipboardText { get; set; }
        public ClipboardEventArgs(string clipboardText)
        {
            ClipboardText = clipboardText;
        }
    }
    class MyTextBox : TextBox
    {
        public event EventHandler<ClipboardEventArgs> Pasted;
        private const int WM_PASTE = 0x0302;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_PASTE)
            {
                var evt = Pasted;
                if (evt != null)
                {
                    evt(this, new ClipboardEventArgs(Clipboard.GetText()));
                    // don't let the base control handle the event again
                    return;
                }
            }
            base.WndProc(ref m);
        }
    }
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var tb = new MyTextBox();
            tb.Pasted += (sender, args) => MessageBox.Show("Pasted: " + args.ClipboardText);
            var form = new Form();
            form.Controls.Add(tb);
            Application.Run(form);
        }
    }
