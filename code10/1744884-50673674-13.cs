        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //code here to setup the value;
            cb_CommPort.Text = Properties.Settings.Default.PortName;
            // other fields
        }
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["PortName"] = CommPortManager.Instance.PortName = cb_CommPort.Text;
            // your code
            Properties.Settings.Default.Save();
        }
