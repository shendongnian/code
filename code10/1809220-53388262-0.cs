        EventWaitHandle waitHandler;
        string replyMessage;
        void string AskForReply()
        {
            //Already requesting something...
            if(waitHandler != null) { return; }
            waitHandler = new EventWaitHandle(false, EventResetMode.AutoReset);
            //Send a request to a remote service
            waitHandler.WaitOne(timeout);
            //Will reply null (or the default value) if the timeout passes.
            return replyMessage;
        }
        void ReceiveReply(string message)
        {
            //We never asked for a reply? (Optional)
            if (waitHandler != null) { return; }
            replyMessage = message;
            //Process your reply
            waitHandler.Set();
            waitHandler = null;
        }
