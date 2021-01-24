        private bool ignoreCallback;
        public void Init(string config)
        {
            // Parse info
            var bits = config.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            this.host = bits[0];
            var hostBytes = this.host.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            var hostIp = new IPAddress(new[] { byte.Parse(hostBytes[0]), byte.Parse(hostBytes[1]), byte.Parse(hostBytes[2]), byte.Parse(hostBytes[3]) });
            this.port = int.Parse(bits[1]);
            this.delayToClearBufferSeconds = int.Parse(bits[2]);
            // Close open client
            if (this.client?.Client != null)
            {
                ignoreCallback = true;
                this.client.Client.Disconnect(true);
                this.client = null;
            }
            // Connect to client
            this.client = new TcpClient();
            if (!this.client.ConnectAsync(hostIp, this.port).Wait(2500))
                throw new Exception($"Failed to connect to {this.host}:{this.port} in allotted time");
            this.EstablishReceiver();
        }
        protected void DataReceived(IAsyncResult result)
        {
            if (ignoreCallback)
            {
                ignoreCallback = false;
                return;
            }
            ...
