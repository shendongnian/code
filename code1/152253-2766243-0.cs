    public class Contact
    {
        string displayname = String.Empty;
        List<Message> history = new List<Message>();
        MessageForm theform = new MessageForm(this);
    
        public void OnEvent(Message msg)
        {
            if(msg.Sender != me && !theform.Visible)
                theform.Show();
        
        }
    
        public void Tell(string message)
        {
        }
    
    }
