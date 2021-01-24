        private Renci.SshNet.SshClient _client = null;
        private Renci.SshNet.ShellStream shellStream = null;
        private void connect()
        {
            try
            {
                this.disConnect();
                _client = new Renci.SshNet.SshClient(cboUri.Text, tbxSrvUsr.Text, tbxSrvPW.Text);
                //_client.ErrorOccurred += new EventHandler<Renci.SshNet.Common.ExceptionEventArgs>(_client_ErrorOccurred);
                //_client.HostKeyReceived += new EventHandler<Renci.SshNet.Common.HostKeyEventArgs>(_client_HostKeyReceived);
                
                _client.Connect();
                byte[] buffer = new byte[1000];
                shellStream = _client.CreateShellStream("Jornathan", 80, 24, 800, 800, 1024);
                shellStream.BeginRead(buffer, 0, buffer.Length, null, null);
                
                shellStream.DataReceived += new EventHandler<Renci.SshNet.Common.ShellDataEventArgs>(shellStream_DataReceived);
                tbxStatus.Text = "Connected";            
                this.btnConnect.Enabled = false;
                this.cboServerList.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
