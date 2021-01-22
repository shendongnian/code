    class WMIEvent {
    	public static void Main() {
    	    WMIEvent we = new WMIEvent();
    	    ManagementEventWatcher w= null;
    	    WqlEventQuery q;
    	    try {
    			q = new WqlEventQuery();
    			q.EventClassName = "Win32_ProcessStartTrace";
    			w = new ProcessStartEventArrived(q);
    			w.EventArrived += new EventArrivedEventHandler(we.ProcessStartEventArriv ed);
    			w.Start();
    			Console.ReadLine(); // block main thread for test purposes
            }
	    	finally {
				w.Stop();
	    	}
   	 }
    	public void ProcessStartEventArrived(object sender, EventArrivedEventArgs e) {    
    		foreach(PropertyData pd in e.NewEvent.Properties) {
    			Console.WriteLine("\n============================= =========");
    			Console.WriteLine("{0},{1},{2}",pd.Name, pd.Type, pd.Value);
    		}
  	  }
