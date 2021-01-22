        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Values.MESSAGE_ASYNC)
            {
                switch (m.LParam.ToInt32())
                {
                    case Values.FD_READ:
                        WS2.Receive();
                        break;
                    case Values.FD_WRITE: break;
                    case Values.FD_CLOSE:
                        WS2.Close();
                        break;
                    default: break;
                }
            }
            else
            {
                base.WndProc(ref m);
            }
        }
