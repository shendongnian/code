    //Class to create new message object
    public class MsgToDB
    {
        public int someInteger;
        public DateTime timeStamp;
        public XElement payload;
    }
    // Create an object of class MsgToDB which will contain envelope object 
    MsgToDB testMsgObj = new MsgToDB();
    testMsgObj.someInteger = 3;
    testMsgObj.timeStamp = DateTime.Now;
    testMsgObj.payload = envelope;
    // Create and send message
    Message testMsg = new Message(testMsgObj);
    myQueue.Send(testMsg, "message label");
