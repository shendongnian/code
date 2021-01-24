C#
using (TcpClient client = new TcpClient(ip, port))
using (NetworkStream stream = client.GetStream())
using (var writeCts = new CancellationTokenSource(TimeSpan.FromSeconds(10)))
{
    byte[] messageBytes = PrepareMessageBytes();
    await stream.WriteAsync(messageBytes, 0, messageBytes.Length, writeCts.Token);
    await stream.FlushAsync();
    byte[] buffer = new byte[1024];
    StringBuilder builder = new StringBuilder();
    int bytesRead = 0;
    while (stream.DataAvailable)
    {
        using (var readCts = new CancellationTokenSource(TimeSpan.FromSeconds(10)))
            bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length, readCts.Token);
        builder.AppendFormat("{0}", Encoding.ASCII.GetString(buffer, 0, bytesRead));
    }
    string msg = receivedMessage.ToString();
}
> I would expect that after 10 seconds, an IOException will be thrown.
When using cancellation tokens, expect an `OperationCanceledException`. Technically, cancellation tokens can be used for a wide variety of cancellation scenarios - the code decides it doesn't need to complete the operation anymore, the user manually canceled the operation, or there was a timeout. `OperationCanceledException` is the generic exception type meaning "canceled".
