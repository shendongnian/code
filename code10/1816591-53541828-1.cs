    // Send address type and address
    SocketWriteByte(0x03); // Resolve by proxy
    var host = SshData.Ascii.GetBytes(ConnectionInfo.Host);
    SocketWriteByte((byte)host.Length);
    SocketAbstraction.Send(_socket, host);
