     public event EventHandler DataReceived;  // the UI form can subscribe to this event
     private void OnReceived()
     {
       //so the FTP has returned data
       // Do stuff here that can be on the background thread like saving
       // the file in an appropriate place, or whatever.
       // now trigger the DataReceived event.  Anyone who cares about data being received
       // can subscribe to this and do whatever is appropriate.
       if (DataReceived) DataReceived(this, EventArgs.Empty); 
