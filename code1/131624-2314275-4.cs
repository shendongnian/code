    public class OtherClass : Form
    {
        public event EventHandler DeviceAttached;
    
        public Start()
        {
            // do things here to initialize receiving messages
        }
    
        protected override void WndProc (ref message m)
        {
           if (....)
           {
              OnDeviceAttach();
           }
           base.WndProc(ref m);
        }
    
            public void OnDeviceAttach()
            {
                if (DeviceAttached != null)
                    DeviceAttached ();
            }
    
    }
