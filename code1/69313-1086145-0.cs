    public class ButtonChange
    {
        private int _buttonState;
        public int ButtonState
        {
            get { return _buttonState; }
            set 
            {
                if (_buttonState == value)
                    return;
                _buttonState = value; 
            }
        }
        public event EventHandler ButtonStateChanged;
        private void OnButtonStateChanged()
        {
            if (this.ButtonStateChanged != null)
                this.ButtonStateChanged(this, new EventArgs());
        }
    }
