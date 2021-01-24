    public class DispatchByBodyOperationSelector : IDispatchOperationSelector
    {
        public string SelectOperation(ref Message message)
        {
            XmlDictionaryReader bodyReader = message.GetReaderAtBodyContents();
    
            //By accessing the body the message is now marked as read, thus we need to clone the message so it's left in an unread state
            //NOTE: We have to pass in the body reader because if we try to get it again it throws an error
            message = CloneMessage(message, bodyReader);
           
            //The element in the body has "Request" appended so we need to remove it to match the method
            return bodyReader.LocalName.Replace("Request", "");
        }
    
        private Message CloneMessage(Message message, XmlDictionaryReader body)
        {
            Message toReturn = Message.CreateMessage(message.Version, message.Headers.Action, body);
    
            toReturn.Headers.CopyHeaderFrom(message, 0);
            toReturn.Properties.CopyProperties(message.Properties);
    
            return toReturn;
        }
    }
