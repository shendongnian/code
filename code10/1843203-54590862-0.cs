    using System.Windows.Forms;
    public class ExRichTextBox : RichTextBox
    {
        const int WM_SETCURSOR = 0x0020;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SETCURSOR)
                Cursor.Current = this.Cursor;
            else
                base.WndProc(ref m);
        }
    }
