        public delegate void TrackingEventHandler(Object sender, TrackingEventArgs e);
        internal Class BaseClass{ }
        internal Class DerivedClass : BaseClass, InterfaceClass
        {
          public event TrackingEventHandler NewTrackingEventObservations;
        }
    }
