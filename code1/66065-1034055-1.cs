    var queue = new BlockingMessageQueue(_MessageQueue);
    while (true) {
      var message = queue.Dequeue();
      if (message.RoutingInfo == Devices.Common.MessageRoutingInfo.ToDevice)
      {
        _Port.SerialPort.WriteLine(message.Message);
      }
      else if (message.RoutingInfo == Devices.Common.MessageRoutingInfo.FromDevice)
      {
        OnDeviceMessageReceived(new Common.DeviceMessageArgs(message.Message));
      }
    }
