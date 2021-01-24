    // Somewhere in your code, probably next to your [msgList] variable...
    private StringBuilder sb = new StringBuilder();
    
    private void OutputMessage(string msg)
    {
        if (!string.IsNullOrEmpty(msg))
        {
            string msgWithTimeStamp = System.DateTime.Now.ToString() + ": \t" + msg;
            msgList.Add(msgWithTimeStamp);
            sb.AppendLine(msgWithTimeStamp);
    
            if (msgList.Count > 500)
            {
                sb.Remove(0, msgList[0].Length + 2); // The +2 is to account for the new line and carriage return characters.
                msgList.RemoveAt(0);
            }
    
            statusMessage = sb.ToString();
        }
    }
