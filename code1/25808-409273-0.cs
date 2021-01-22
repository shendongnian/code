    // Accepts full array.
    TcpHeader Parse(byte[] buffer)
    {
        // Call the overload.
        return Parse(new ArraySegment<byte>(buffer));
    }
    // Changed TCPHeader to TcpHeader to adhere to public naming conventions.
    TcpHeader Parse(ArraySegment<byte> buffer)
