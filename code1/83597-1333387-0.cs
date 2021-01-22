    // In Class2
        public event EventHandler<EventArgs<T>> ControlClickedEvent = null;
        protected void OnControlClickedEvent()
        {
            if (ControlClickedEvent != null)
            {
                ControlClickedEvent(this, new EventArgs());  
            }
        }
      ...
       private void cmdButton_Click(object sender, EventArgs e)
       {
            OnControlClickedEvent();
       }
