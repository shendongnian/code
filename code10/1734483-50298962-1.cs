    public class MyMagicTextbox : TextBox
    {
        public event EventHandler<EventArgs> MyMagicEvent;
    
        protected virtual void OnMyMagicEvent(EventArgs e)
        {
            MyMagicEvent?.Invoke(this, e);
        }
    }
