    class IncomingMessageEventArgs : EventArgs{
        IncomingMessageType message;
        public IncomingMessageType Message{get{return message;}}
        public IncomingMessageEventArgs(IncomingMessageType message){
            this.message = message;
        }
    }
    class TheIncomingDataClass{
        public event EventHandler<IncomingMessageEventArgs> MessageReceived;
        protected virtual void OnMessageReceived(IncomingMessageEventArgs e){
            if(MessageReceived != null)
                MessageReceived(this, e);
        }
        public void IncomingMessage(IncomingMessageType message){
            OnMessageReceived(new IncomingMessageEventArgs(message));
        }
    }
    class MainForm : Form{
        MainForm(){
            new TheIncomingDataClass().MessageReceived +=
                (s, e)=>txtDisplayMessages.AppendText(e.Message.ToString());
        }
    }
