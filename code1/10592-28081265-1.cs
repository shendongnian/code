    namespace CancelSample
    {
        using System;
        using System.Threading;
        using System.Runtime.InteropServices;
        internal class Program
        {
            /// <summary>
            /// Adds or removes an application-defined HandlerRoutine function from the list of handler functions for the calling process
            /// </summary>
            /// <param name="handler">A pointer to the application-defined HandlerRoutine function to be added or removed. This parameter can be NULL.</param>
            /// <param name="add">If this parameter is TRUE, the handler is added; if it is FALSE, the handler is removed.</param>
            /// <returns>If the function succeeds, the return value is true.</returns>
            [DllImport("Kernel32")]
            private static extern bool SetConsoleCtrlHandler(ConsoleCloseHandler handler, bool add);
            /// <summary>
            /// The console close handler delegate.
            /// </summary>
            /// <param name="closeReason">
            /// The close reason.
            /// </param>
            /// <returns>
            /// True if cleanup is complete, false to run other registered close handlers.
            /// </returns>
            private delegate bool ConsoleCloseHandler(int closeReason);
            /// <summary>
            ///  Event set when the process is terminated.
            /// </summary>
            private static readonly ManualResetEvent TerminationRequestedEvent;
            /// <summary>
            /// Event set when the process terminates.
            /// </summary>
            private static readonly ManualResetEvent TerminationCompletedEvent;
            /// <summary>
            /// Static constructor
            /// </summary>
            static Program()
            {
                // Do this initialization here to avoid polluting Main() with it
                // also this is a great place to initialize multiple static
                // variables.
                TerminationRequestedEvent = new ManualResetEvent(false);
                TerminationCompletedEvent = new ManualResetEvent(false);
                SetConsoleCtrlHandler(OnConsoleCloseEvent, true);
            }
            /// <summary>
            /// The main console entry point.
            /// </summary>
            /// <param name="args">The commandline arguments.</param>
            private static void Main(string[] args)
            {
                // Wait for the termination event
                while (!TerminationRequestedEvent.WaitOne(0))
                {
                    // Something to do while waiting
                    Console.WriteLine("Work");
                }
                // Sleep until termination
                TerminationRequestedEvent.WaitOne();
                // Print a message which represents the operation
                Console.WriteLine("Cleanup");
                // Set this to terminate immediately (if not set, the OS will
                // eventually kill the process)
                TerminationCompletedEvent.Set();
            }
            /// <summary>
            /// Method called when the user presses Ctrl-C
            /// </summary>
            /// <param name="reason">The close reason</param>
            private static bool OnConsoleCloseEvent(int reason)
            {
                // Signal termination
                TerminationRequestedEvent.Set();
                // Wait for cleanup
                TerminationCompletedEvent.WaitOne();
                // Don't run other handlers, just exit.
                return true;
            }
        }
    }
