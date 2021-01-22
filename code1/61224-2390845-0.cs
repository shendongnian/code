        /// <summary>
        /// Invoke the element's thread using a dispatcher. This is needed for changing WPF element attributes.
        /// </summary>
        /// <param name="dispatcherObject">The element of which to use the thread.</param>
        /// <param name="action">The action to do with the invoked thread.</param>
        /// <param name="dispatcherPriority">The priority of this action.</param>
        public static void DoInvoked(this System.Windows.Threading.DispatcherObject dispatcherObject, Action action, System.Windows.Threading.DispatcherPriority dispatcherPriority = System.Windows.Threading.DispatcherPriority.Render)
        {
            if (System.Threading.Thread.CurrentThread == dispatcherObject.Dispatcher.Thread)
            {
                action();
            }
            else
            {
                dispatcherObject.Dispatcher.BeginInvoke(action, dispatcherPriority, null);
            }
        }
