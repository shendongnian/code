    public async Task ConnectDevice(IDevice device,CancellationTokenSource cancelSrc)
        {
            await Task.Run(() =>
            {
                device.Connect();
                while ((cancelSrc.Token.IsCancellationRequested==false)&&(device.IsConnected() == false))
                {
                    
                }
            }, cancelSrc.Token);
        }
