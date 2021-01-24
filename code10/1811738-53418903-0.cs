    // needed to bind the inspector to the client channel
    // other methods are empty
    internal class LoggingBehaviour : IEndpointBehavior
    {
        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.ClientMessageInspectors.Add(new LoggingClientMessageInspector());
        }
    }
    internal class LoggingClientMessageInspector : IClientMessageInspector
    {
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            var correlationId = Guid.NewGuid();
            this.SaveLog(ref request, correlationId, "RQ");
            return correlationId;
        }
        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            var correlationId = (Guid)correlationState;
            this.SaveLog(ref reply, correlationId, "RS");
        }
        private void SaveLog(ref Message request, Guid correlationId, string suffix)
        {
            var outputPath = GetSavePath(suffix, correlationId, someOtherData);
            using (var buffer = request.CreateBufferedCopy(int.MaxValue))
            {
                var directoryName = Path.GetDirectoryName(outputPath);
                if (directoryName != null)
                {
                    Directory.CreateDirectory(directoryName);
                }
                using (var stream = File.OpenWrite(outputPath))
                {
                    using (var message = buffer.CreateMessage())
                    {
                        using (var writer = XmlWriter.Create(stream))
                        {
                            message.WriteMessage(writer);
                        }
                    }
                }
                request = buffer.CreateMessage();
            }
        }
    }
