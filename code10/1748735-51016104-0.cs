     private void SetupBluetoothListner()
        {
            _messageServiceId = new Guid("{646171EA-EA18-4CCF-8D7A-C57D46991775}");
            _isBluetoothRecieverStarted = true;
            if (_cancelToken != null && _messageListener != null)
            {
                this.Dispose(true);
            }
            _cancelToken = new CancellationTokenSource();
            _messageListener = new BluetoothListener(_messageServiceId)
            {
                ServiceName = Constants.BluetoothStringMessageService
            };
        }
    
     private void BluetoothListener(CancellationTokenSource cancelToken, BluetoothListener bluetoothListener)
        {
            try
            {
                while (true)
                {
                    using (var client = bluetoothListener.AcceptBluetoothClient())
                    {
                        if (cancelToken.IsCancellationRequested)
                        {
                            return;
                        }
                        using (var streamReader = new StreamReader(client.GetStream()))
                        {
                            try
                            {
                              var content = streamReader.ReadToEnd();
                              if (!string.IsNullOrEmpty(content))
                              {
                                 MessageReceiver(content);
                              }
                            }
                            catch (IOException ex)
                            {
                                client.Close();
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Constants.ErrorAtReceivingStringMessage, MessageBoxButton.OK);
            }
        }
       private bool SendData(Device device, byte[] content)
        {
            using (var bluetoothClient = new BluetoothClient())
            {
                try
                {
                    var endpoint = new BluetoothEndPoint(device.DeviceInfo.DeviceAddress, _messageServiceId);
                    bluetoothClient.Connect(endpoint);
                    var bluetoothStream = bluetoothClient.GetStream();
                    if (bluetoothClient.Connected && bluetoothStream != null)
                    {
                        bluetoothStream.Write(content, 0, content.Length);
                        bluetoothStream.Flush();
                        bluetoothStream.Close();
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                  // TODO: handle exception
                }
            }
            return false;
        }
