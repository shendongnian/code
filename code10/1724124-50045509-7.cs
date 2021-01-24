    public class EventCapture
    {
        public event Action OnClick;
        public void SimulateClick()
        {
            InvokeClicked();
        }
        // This method will call the event from VRInput!
        private void InvokeClicked()
        {
            var handler = OnClick;
            if (handler != null)
                handler();
        }
    }
