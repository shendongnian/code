    var buffer = new byte[Resources.MaxBufferSize];
    var contentLength = 0;
    while (_tcpClient.Connected)
    {
      if (!_networkStream.CanRead || !_networkStream.DataAvailable)
        continue;
      var bytesRead = _networkStream.Read(buffer, contentLength, buffer.Length - contentLength - 1);
      contentLength += bytesRead;
      var message = string.Empty;
      do
      {
        message = ExtractMessage(ref buffer, ref contentLength);
        if (!String.IsNullOrEmpty(message))
        {
          if (MessageReceived != null)
          {
            MessageReceived(this, new SimpleTextClientEventArgs(message));
          }                        
        }
      } while (message != string.Empty);
    }
    private string ExtractMessage(ref byte[] buffer, ref int length)
    {
      var message = string.Empty;
      var stringBuffer = Encoding.UTF8.GetString(buffer, 0, length);
      var lineBreakPosition = stringBuffer.IndexOf(Resources.LineBreak);
      if (lineBreakPosition > -1)
      {
        message = stringBuffer.Substring(0, lineBreakPosition);
        var tempBuffer = new byte[Resources.MaxBufferSize];
        length = length - message.Length - Resources.LineBreak.Length;
        if (length > 0)
        {
          Array.Copy(buffer, lineBreakPosition + Resources.LineBreak.Length, tempBuffer, 0, length);
          buffer = tempBuffer;
        }
      }
      return message;
    }
