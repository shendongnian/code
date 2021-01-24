    public class MyMagicTextbox : TextBox
    {
        public event EventHandler<EventArgs> MyMagicEvent;
    
        public virtual void OnMyMagicEvent(EventArgs e)
        {
            MyMagicEvent?.Invoke(this, e);
        }
    }
