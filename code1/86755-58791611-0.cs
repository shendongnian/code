private async Task TestConnectionLoop()
{
    byte[] buffer = new byte[1];
    ArraySegment<byte> arraySegment = new ArraySegment<byte>(buffer, 0, 0);
    SocketFlags flags = SocketFlags.None;
    while (!_cancellationSource.Token.IsCancellationRequested)
    {
        try
        {
            await _soc.SendAsync(arraySegment, flags);
            await Task.Delay(500);
        }
        catch (Exception e)
        {
            _cancellationSource.Cancel();
            // Others can listen to the Cancellation Token or you 
            // can do other actions here
        }
    }
}
