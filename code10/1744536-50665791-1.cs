    public string GetBuffer()
    {
        var messages = new StringBuilder();
        while (_logMessageBuffer.TryDequeue(out var message))
        {   
            messages.AppendLine(message);   
        }       
        return messages.ToString();
    }
