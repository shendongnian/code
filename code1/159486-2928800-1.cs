    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Timers;
    using System.Diagnostics;
    
    namespace Service.Queue
    {
        /// <summary>
        /// Process Queue Singleton Class
        /// </summary>
        class ProcessQueue : IDisposable
        {
    		
            private static readonly ProcessQueue _instance = new ProcessQueue();
            private bool _IsProcessing = false;
    	    int _maxMessages = 700;
    
            public bool IsProcessing
            {
                get { return _IsProcessing; }
                set { _IsProcessing = value; }
            }
            
            ~ProcessQueue()
            {
                Dispose(false);
            }
    
            public static ProcessQueue Instance
            {
                get
                {
                    return _instance;
                }
            }
    
    
            /// <summary>
            /// Timer for Process Queue
            /// </summary>
            Timer timer = new Timer();
    
            /// <summary>
            /// Starts Process Queue
            /// </summary>
            public void Start()
            {
                timer.Elapsed += new ElapsedEventHandler(OnProcessEvent);
                timer.Interval = 1000;
                timer.Enabled = true;
            }
    
            /// <summary>
            /// Stops Process Queue
            /// </summary>
            public void Stop() {
                _IsProcessing = false;
                timer.Enabled = false;
            }
    
            /// <summary>
            /// Process Event Handler
            /// /// </summary>
            private void OnProcessEvent(object source, ElapsedEventArgs e)
            {
                if (!_IsProcessing)
                {
                    _IsProcessing = true;
    
    		for (int i = 0; i < _maxMessages; i++)
                    {
    		    TRxMsg receivedMessage;
    		    ReadMessage(devHandle, out receivedMessage);
    		}
    		
                    _IsProcessing = false;
                }
    
            }
    
            protected virtual void Dispose(bool disposing)
            {
                if (disposing)
                {
                    timer.Dispose();
                }
            }
    
            #region IDisposable Members
    
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
    
            #endregion
    
        }
    }
