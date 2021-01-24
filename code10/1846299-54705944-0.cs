    var enc = Encoding.ASCII;            
    byte[] bytes = ArrayPool<byte>.Shared.Rent(enc.GetMaxByteCount(message.Length));
    int byteCount = enc.GetBytes(message, 0, message.Length, bytes, 0);
    tcpClient.GetStream().Write(bytes, 0, byteCount);
    ArrayPool<byte>.Shared.Return(bytes);
