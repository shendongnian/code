    [MessageContract]
    public class SizedStreamMessage
    {
       [MessageHeader]
       public long streamSize;
    
       [MessageBody] //Has to be just one MessageBody for streaming to work!
       public Stream theStream;
    }
