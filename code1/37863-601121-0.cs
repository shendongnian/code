    // Async callback.
    Message message;
    
    while((message = Message.ReadBytes(ref messageBuffer)) != null)
    {
        OnMessageReceived(new MessageEventArgs(message));
    }
    
    // Message class.
    public static Message ReadBytes(ref List<byte> data)
    {
    	int end = data.FindIndex(b => b == '\n' || b == '\r');
    
    	if(end == -1)
    		return null;
    
    	string line = Encoding.UTF8.GetString(data.Take(end).ToArray());
    
    	data.RemoveRange(0, end + 1);
    
    	if(line == "")
    		return ReadBytes(ref data);
    
    	if(line == null)
    		return null;
    
    	return Message.FromRawString(line);
    }
