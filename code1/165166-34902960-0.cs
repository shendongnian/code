    private async void ReceiveBytesAsync(IPEndPoint filter)
	{
		UdpReceiveResult receivedBytes  = await this._udpClient.ReceiveAsync();
		if (filter != null)
		{
			if (receivedBytes.RemoteEndPoint.Address.Equals(filter.Address) &&
					(receivedBytes.RemoteEndPoint.Port.Equals(filter.Port)))
			{
				// process received data
			}
		}
	}
