        /// <summary>
        /// Enters the message loop to process all pending messages down to the specified
        /// priority. This method returns after all messages have been processed.
        /// </summary>
        /// <param name="priority">Minimum priority of the messages to process.</param>
        public static void DoEvents(DispatcherPriority priority = DispatcherPriority.Background)
        {
            DispatcherFrame frame = new DispatcherFrame();
            Dispatcher.CurrentDispatcher.BeginInvoke(
                priority,
                new DispatcherOperationCallback(ExitFrame), frame);
            Dispatcher.PushFrame(frame);
        }
        private static object ExitFrame(object f)
        {
            ((DispatcherFrame)f).Continue = false;
            return null;
        }
    
