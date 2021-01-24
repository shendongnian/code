    public async Task<T> SendRequest<T>(IFrame request) where T : IFrame, new()
    {
        var data = request.ToByteArray();
        var stream = this.TCPConnection.GetStream();
        await stream.WriteAsync(data, 0, data.Length);
        data = new byte[this.BUFFER_SIZE];
        var quantityBytes = await stream.ReadAsync(data, 0, data.Length);
        var frameResponse = data.Take(quantityBytes).ToArray();
        var response = new T
        {
            FrameHeader = frameResponse[0],
            Lenght = frameResponse[1],
            FunctionCode = frameResponse[2],
            Data = (frameResponse[1] == 0) ? null : data.ToDataField(quantityBytes),
            Checksum = frameResponse[frameResponse.Length - 1]
        };
        if(response.Checksum != response.VerifyChecksum())
            throw new Exception("Err in Checksum!");
        return response;
    }
