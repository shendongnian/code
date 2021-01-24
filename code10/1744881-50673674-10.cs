        private void btn_Connect_Click(object sender, EventArgs e)
        {
            CommPortManager.Instance.PortName = cb_CommPort.Text;
            CommPortManager.Instance.BaudRate = cb_BaudRate.Text;
            CommPortManager.Instance.Parity = cb_Parity.Text;
            CommPortManager.Instance.StopBits = cb_StopBits.Text;
            CommPortManager.Instance.DataBits = cb_DataBits.Text;
            if ((cb_CommPort.Text == "") || (cb_BaudRate.Text == "") || (cb_Parity.Text == "") || (cb_DataBits.Text == "") || (cb_StopBits.Text == ""))
            {
                MessageBox.Show("Please select all communication settings and then Save", "TestCertificate", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (!CommPortManager.Instance.IsOpen)
                {
                    if (CommPortManager.Instance.COM_Open() == false)
                    {
                        MessageBox.Show("Could not open the COM port. Most likely it is already in use, has been removed, or is unavailable.", "TestCertificate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        btn_Connect.Text = "Disconnect";
                    }
                }
                else
                {
                    CommPortManager.Instance.COM_Close();
                    // you should not close the 
                    btn_Connect.Text = "Connect";
                }
            }
        }
