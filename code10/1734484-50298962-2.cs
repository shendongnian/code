    public class MyMagicTextbox : TextBox
    {
        public event EventHandler<EventArgs> MyMagicEvent;
        protected virtual void OnMyMagicEvent(EventArgs e)
        {
            MyMagicEvent?.Invoke(this, e);
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                OnMyMagicEvent(EventArgs.Empty);
            base.OnMouseClick(e);
        }
    }
