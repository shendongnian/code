    public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
    {
        MessageBuffer buffer = request.CreateBufferedCopy(Int32.MaxValue);
        request = buffer.CreateMessage();
        XDocument doc;
        using (MemoryStream ms = new MemoryStream())
        {
            XmlWriter writer = XmlWriter.Create(ms);
            request.WriteMessage(writer);
            writer.Flush();
            ms.Position = 0;
            
            doc = XDocument.Load(ms);
        }
        if (SaveLog != null)
        {
            LogSaveFileEventArgs logEventArgs = new LogSaveFileEventArgs(doc, false);
            SaveLog(this, logEventArgs);
        }
        request = buffer.CreateMessage();
        //The return value can be any object that you want to use for correlation purposes;
        //it is returned to you as the correlationState parameter in the BeforeSendReply method.
        return null;
    }
