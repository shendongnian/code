    var ResultMsg = new List<byte>();
    if (receiver.Array.Length > 0)
    {
    	ResultMsg.AddRange(receiver.Array.Take(result.Count));
    }
    if (result.EndOfMessage)
    {
    	var msgBytes = ResultMsg.ToArray();
    	var message = Encoding.UTF8.GetString(msgBytes);
    	TextMessageHandler(message);
    	ResultMsg.Clear();
    }
