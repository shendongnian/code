    using System;
    using System.Threading;
    using Xamarin.Forms;
    
    namespace CryptoTracker.Helpers
    {
    	/// <summary>
        /// This timer is used to poll the middleware for new information.
        /// </summary>
        public class PollingTimer
        {
            private readonly TimeSpan timespan;
            private readonly Action callback;
    
            private CancellationTokenSource cancellation;
    
            /// <summary>
            /// Initializes a new instance of the <see cref="T:CryptoTracker.Helpers.PollingTimer"/> class.
            /// </summary>
            /// <param name="timespan">The amount of time between each call</param>
            /// <param name="callback">The callback procedure.</param>
            public PollingTimer(TimeSpan timespan, Action callback)
            {
                this.timespan = timespan;
                this.callback = callback;
                this.cancellation = new CancellationTokenSource();
            }
    
            /// <summary>
            /// Starts the timer.
            /// </summary>
            public void Start()
            {
                CancellationTokenSource cts = this.cancellation; // safe copy
                Device.StartTimer(this.timespan,
                    () => {
                        if (cts.IsCancellationRequested) return false;
                        this.callback.Invoke();
                        return true; // or true for periodic behavior
                });
            }
    
            /// <summary>
            /// Stops the timer.
            /// </summary>
            public void Stop()
            {
                Interlocked.Exchange(ref this.cancellation, new CancellationTokenSource()).Cancel();
            }
        }
    }
