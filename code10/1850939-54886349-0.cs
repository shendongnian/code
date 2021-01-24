C#
public static async Task AuthenticateQvpx2()
{
  var handshake = new Handshake();
  foreach (var request in handshake.AutheticateStrings)
  {
    var buffer = _encoder.GetBytes(request);
    var receiveTask = Receive(_webSocket);
    await Task.WhenAll(receiveTask, Send(_webSocket, buffer));
    var response = await receiveTask;
  }
}
