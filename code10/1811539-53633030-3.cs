    static byte[] SendMessage(byte[] message, TimeSpan timeout)
    {
        // Use stopwatch to update SerialPort.ReadTimeout and SerialPort.WriteTimeout 
        // as we go.
        var stopwatch = Stopwatch.StartNew();
        // Organize critical section for logical operations using some standard .NET tool.
        lock (_syncRoot)
        {
            var originalWriteTimeout = _serialPort.WriteTimeout;
            var originalReadTimeout = _serialPort.ReadTimeout;
            try
            {
                // Start logical request.
                _serialPort.WriteTimeout = (int)Math.Max((timeout - stopwatch.Elapsed).TotalMilliseconds, 0);
                _serialPort.Write(message, 0, message.Length);
                // Expected response length. Look for the constant value from 
                // the device communication protocol specification or extract 
                // from the response header (first response bytes) if there is 
                // any specified in the protocol.
                int count = ...;
                byte[] buffer = new byte[count];
                int offset = 0;
                // Loop until we recieve a full response.
                while (count > 0)
                {
                    _serialPort.ReadTimeout = (int)Math.Max((timeout - stopwatch.Elapsed).TotalMilliseconds, 0);
                    var readCount = _serialPort.Read(buffer, offset, count);
                    offset += readCount;
                    count -= readCount;
                }
                return buffer;
            }
            finally
            {
                // Restore SerialPort state.
                _serialPort.ReadTimeout = originalReadTimeout;
                _serialPort.WriteTimeout = originalWriteTimeout;
            }
        }
    }
