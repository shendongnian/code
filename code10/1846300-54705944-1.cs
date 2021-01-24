    var enc = Encoding.ASCII;
    byte[] bytes = ArrayPool<byte>.Shared.Rent(enc.GetMaxByteCount(message.Length));
    // note: leased buffers can be oversized; and in general, GetMaxByteCount will
    // also be oversized; so it is *very* important to track how many bytes you've used
    int byteCount = enc.GetBytes(message, 0, message.Length, bytes, 0);
    tcpClient.GetStream().Write(bytes, 0, byteCount);
    ArrayPool<byte>.Shared.Return(bytes);
