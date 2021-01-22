        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);
        const int WM_USER = 0x400;
        const int EM_HIDESELECTION = WM_USER + 63;
        void OnAppend(string text)
        {
            bool focused = richTextBox1.Focused;
            //backup initial selection
            int selection = richTextBox1.SelectionStart;
            int length = richTextBox1.SelectionLength;
            //allow autoscroll if selection is at end of text
            bool autoscroll = (selection==richTextBox1.Text.Length);
            if (!autoscroll)
            {
                //shift focus from RichTextBox to some other control
                if (focused) textBox1.Focus();
                //hide selection
                SendMessage(richTextBox1.Handle, EM_HIDESELECTION, 1, 0);
            }
            richTextBox1.AppendText(text);
            if (!autoscroll)
            {
                //restore initial selection
                richTextBox1.SelectionStart = selection;
                richTextBox1.SelectionLength = length;
                //unhide selection
                SendMessage(richTextBox1.Handle, EM_HIDESELECTION, 0, 0);
                //restore focus to RichTextBox
                if(focused) richTextBox1.Focus();
            }
        }
