        private void btn_Connect_Click(object sender, EventArgs e)
        {
            if (btn_Connect.Text == "Connect")
            {
                CommPortManager.Instance.PortName = cb_CommPort.Text;
                CommPortManager.Instance.BaudRate = cb_BaudRate.Text;
                CommPortManager.Instance.Parity = cb_Parity.Text;
                CommPortManager.Instance.StopBits = cb_StopBits.Text;
                CommPortManager.Instance.DataBits = cb_DataBits.Text;
                if ((cb_CommPort.Text == "") || (cb_BaudRate.Text == "") || (cb_Parity.Text == "") || (cb_DataBits.Text == "") || (cb_StopBits.Text == ""))
                {
                    if (cb_CommPort.Text == "")
                    {
                        MessageBox.Show("Please select COM Port and then Connect", "TestCertificate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (cb_BaudRate.Text == "")
                    {
                        MessageBox.Show("Please select BaudRate and then Connect", "TestCertificate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (cb_Parity.Text == "")
                    {
                        MessageBox.Show("Please select Parity and then Connect", "TestCertificate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (cb_DataBits.Text == "")
                    {
                        MessageBox.Show("Please select DataBits and then Connect", "TestCertificate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (cb_StopBits.Text == "")
                    {
                        MessageBox.Show("Please select StopBits and then Connect", "TestCertificate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    Connect_Status = false;
                }
                else
                {
                    if (CommPortManager.Instance.COM_Open() == false)
                    {
                        MessageBox.Show("Could not open the COM port. Most likely it is already in use, has been removed, or is unavailable.", "TestCertificate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Connect_Status = false;
                    }
                    else
                    {
                        //commenting this because when its COM_Open is success closing the Com port
                        //CommPortManager.Instance.COM_Close();
                        Connect_Status = true;
                        btn_Connect.Text = "Disconnect";
                        cb_CommPort.Enabled = false;
                        cb_BaudRate.Enabled = false;
                        cb_DataBits.Enabled = false;
                        cb_Parity.Enabled = false;
                        cb_StopBits.Enabled = false;
                        btn_Connect.BackColor = System.Drawing.Color.Salmon;
                    }
                }
            }
            else
            {
                CommPortManager.Instance.COM_Close();
                btn_Connect.Text = "Connect";
                Connect_Status = false;
                cb_CommPort.Enabled = true;
                cb_BaudRate.Enabled = true;
                cb_DataBits.Enabled = true;
                cb_Parity.Enabled = true;
                cb_StopBits.Enabled = true;
                btn_Connect.BackColor = System.Drawing.Color.DarkTurquoise;
            }
        
