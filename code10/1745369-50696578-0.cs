        private void Connect_Load(object sender, EventArgs e)
        {
            //code here to setup the value;
            cb_CommPort.Text = CommPortManager.Instance.PortName;
            cb_BaudRate.Text = CommPortManager.Instance.BaudRate;
            cb_Parity.Text = CommPortManager.Instance.Parity;
            cb_StopBits.Text = CommPortManager.Instance.StopBits;
            cb_DataBits.Text = CommPortManager.Instance.DataBits;
            if (CommPortManager.Instance.IsOpen == true)
            {
                Connect_Status = true;
                btn_Connect.Text = "Disconnect";
                btn_Connect.BackColor = System.Drawing.Color.Salmon;
                cb_CommPort.Enabled = false;
                cb_BaudRate.Enabled = false;
                cb_DataBits.Enabled = false;
                cb_Parity.Enabled = false;
                cb_StopBits.Enabled = false;
            }
            else
            {
                btn_Connect.Text = "Connect";
                Connect_Status = false;
                cb_CommPort.Enabled = true;
                cb_BaudRate.Enabled = true;
                cb_DataBits.Enabled = true;
                cb_Parity.Enabled = true;
                cb_StopBits.Enabled = true;
                btn_Connect.BackColor = System.Drawing.Color.DarkTurquoise;
            }
        }
