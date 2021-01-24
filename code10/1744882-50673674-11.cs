        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //code here to setup the value;
            cb_CommPort.Text = CommPortManager.Instance.PortName;
            cb_BaudRate.Text = CommPortManager.Instance.BaudRate;
            cb_Parity.Text = CommPortManager.Instance.Parity;
            cb_StopBits.Text = CommPortManager.Instance.StopBits;
            cb_DataBits.Text = CommPortManager.Instance.DataBits;
            btn_Connect.Text = CommPortManager.Instance.IsOpen ? "Disconnect" : "Connect";
        }
