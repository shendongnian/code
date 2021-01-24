    [TestMethod]
    public async Task Send_FailsOnWrongHostName()
    {
        var name = "FailWithHostname";
        var msg = new Message(MyStates.Register, "UnitTest", "Test");
        try
        {
            var client = new PipeClient();
            await client.Send("lol", name, msg);
        }
        catch (Exception e)
        {
            Assert.IsTrue(e is ArgumentException);
        }
    }
    public class PipeClient : IPipeClient
    {
        public async Task Send(string host, string pipeName, Message msg)
        {
            if (string.IsNullOrEmpty(msg.PreparedMessage))
                throw new ArgumentException("MESSAGE_NOT_FOUND");
    
            if (string.IsNullOrEmpty(host) || string.IsNullOrEmpty(pipeName))
                throw new ArgumentNullException();
    
            if (!host.TryParseHost()) 
                throw new ArgumentException("INVALID_HOST_NAME");
    
            using (var pipeClient = new NamedPipeClientStream(host, pipeName, PipeDirection.Out))
            {
                pipeClient.Connect(200);
    
                using (var writer = new StreamWriter(pipeClient))
                {
                    await Task.Run(() => writer.WriteLine(msg.PreparedMessage));
                    writer.Flush();
                }
            }
        }
    }
