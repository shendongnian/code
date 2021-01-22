    public class Scanning
    {
        private System.Timers.Timer aTimer;
        short scan_result;
        public Scanning()
        {
            aTimer = new System.Timers.Timer(1000);
            // Hook up the Elapsed event for the timer.
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        }
    
        private void ButtonScanAndParse_Click(object sender, EventArgs e)
        {
           aTimer.Enabled = true;
           scan_result = scanner_api.Scan();
        }    
 
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
           if (scan_result == 1)
           {
              aTimer.Enabled = false;
              parse_api.Parse(); // This will check for a saved image the scanner_api stores on disk, and then convert it.
           }
        }
    }
