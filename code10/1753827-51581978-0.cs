        public Form1()
        {      
          InitializeComponent();
          controller.EventContext = WindowsFormsSynchronizationContext.Current;
          controller.FrameReady += getXYZValues;
        }
