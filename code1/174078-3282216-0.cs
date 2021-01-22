    class MyMessageFilter : IMessageFilter
    {
        public bool PreFilterMessage(ref Message msg)
        {
            try
            {
                const int WM_LBUTTONUP = 0x0202;
                const int WM_RBUTTONUP = 0x0205;
                const int WM_CHAR = 0x0102;
                const int WM_SYSCHAR = 0x0106;
                const int WM_KEYDOWN = 0x0100;
                const int WM_SYSKEYDOWN = 0x0104;
                const int WM_KEYUP = 0x0101;
                const int WM_SYSKEYUP = 0x0105;
                //Debug.WriteLine("MSG " + msg.Msg.ToString("D4") + " 0x" + msg.Msg.ToString("X4"));
                switch (msg.Msg)
                {
                    case WM_LBUTTONUP:
                    case WM_RBUTTONUP:
                        {
                            Point screenPos = Cursor.Position;
                            Form activeForm = Form.ActiveForm;
                            if (activeForm != null)
                            {
                                Point clientPos = activeForm.PointToClient(screenPos);
                                RecordMouseUp(clientPos.X, clientPos.Y, GetFullControlName(msg.HWnd));
                            }
                        }
                }
            }
        }
        private string GetFullControlName(IntPtr hwnd)
        {
            Control control = Control.FromHandle(hwnd);
            return control.Name; // May need to iterate up parent controls to get a full path.
        }      
    }
