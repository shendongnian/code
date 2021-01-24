    public event EventHandler<OkButtonPressedEventArgs> OkButtonPressed;
    protected void OnOkButtonPressed()
    {
        OkButtonPressedEventArgs args = new OkButtonPressedEventArgs()
        {
            TimeStamp = DateTime.Now
        };
        OkButtonPressed?.Invoke(this, args);
    }
    public class OkButtonPressedEventArgs : EventArgs
    {
        public DateTime TimeStamp { get; set; }
    }
