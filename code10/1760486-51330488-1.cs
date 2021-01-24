    class Test
    {
        private System.Timers.Timer _timer;
        public Test( )
        {
            _timer = new System.Timers.Timer
            {
                // Interval set to 1 second.
                Interval = 1,
                AutoReset = true,                
            };
            _timer.Elapsed += _timer_Elapsed;
            _timer.Enabled = true;
            _timer.Start( );
        }
        private void _timer_Elapsed( object sender, System.Timers.ElapsedEventArgs e )
        {
            // This handler is not executed on the gui thread so
            // you'll have to marshal the call to the gui thread
            // and then update your property.
           var grabber = new CpuInfoGrabber();
           var data = grabber.CpuPerUsed();
           Application.Current.Dispatcher.Invoke( ( ) => Bnd.PerCpu = data );
        }
    }
