    public class RdpClient : AxMSTSCLib.AxMsRdpClient71
    {
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0021)
            {
                Focus();
            }
            base.WndProc(ref m);
        }
    }
