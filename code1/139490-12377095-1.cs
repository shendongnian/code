    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    /// <summary>
    /// A <see cref="NativeWindow"/> for the main application window. Used
    /// to be able to run things on the UI thread and manage window message
    /// callbacks.
    /// </summary>
    public class NativeWindowWithCallbacks : NativeWindow, IDisposable
    {
        /// <summary>
        /// Used to synchronize access to <see cref="NativeWindow.Handle"/>.
        /// </summary>
        private readonly object handleLock = new object();
    
        /// <summary>
        /// Queue of methods to run on the UI thread.
        /// </summary>
        private readonly Queue<MethodArgs> queue = new Queue<MethodArgs>();
    
        /// <summary>
        /// The message handlers.
        /// </summary>
        private readonly Dictionary<int, MessageHandler> messageHandlers = 
            new Dictionary<int, MessageHandler>();
    
        /// <summary>
        /// Windows message number to prompt running methods on the UI thread.
        /// </summary>
        private readonly int runOnUiThreadWindowsMessageNumber =
            Win32.RegisterWindowMessage(
                    "NativeWindowWithCallbacksInvokeOnGuiThread");
    
        /// <summary>
        /// Handles the message.
        /// </summary>
        /// <param name="sender">
        /// The this.
        /// </param>
        /// <param name="m">
        /// The message.
        /// </param>
        /// <returns>
        /// True if done processing; false otherwise. Normally, returning
        /// true will stop other handlers from being called, but, for
        /// some messages (like WM_DESTROY), the return value has no effect.
        /// </returns>
        public delegate bool MessageHandler(object sender, ref Message m);
    
        /// <summary>
        /// Gets a value indicating whether the caller must call BeginInvoke
        /// when making UI calls (like <see cref="Control.InvokeRequired"/>).
        /// </summary>
        /// <returns>
        /// True if not running on the UI thread.
        /// </returns>
        /// <remarks>
        /// This can get called prior to detecting the main window (likely if 
        /// the main window has yet to be created). In this case, this method
        /// will return true even if the main window subsequently gets
        /// created on the current thread. This behavior works for queuing up
        /// methods that will update the main window which is likely the only 
        /// reason for invoking methods on the UI thread anyway.
        /// </remarks>
        public bool InvokeRequired
        {
            get
            {
                int pid;
                return this.Handle != IntPtr.Zero
                    && Win32.GetWindowThreadProcessId(
                            new HandleRef(this, this.Handle), out pid)
                    != Win32.GetCurrentThreadId();
            }
        }
    
        /// <summary>
        /// Like <see cref="Control.BeginInvoke(Delegate,Object[])"/> but
        /// probably not as good.
        /// </summary>
        /// <param name="method">
        /// The method.
        /// </param>
        /// <param name="args">
        /// The arguments.
        /// </param>
        /// <remarks>
        /// This can get called prior to finding the main window (likely if 
        /// the main window has yet to be created). In this case, the method 
        /// will get queued and called upon detection of the main window.
        /// </remarks>
        public void BeginInvoke(Delegate method, params object[] args)
        {
            // TODO: ExecutionContext ec = ExecutionContext.Capture();
            // TODO: then ExecutionContext.Run(ec, ...) 
            // TODO: in WndProc for more accurate security
            lock (this.queue)
            {
                this.queue.Enqueue(
                    new MethodArgs { Method = method, Args = args });
            }
    
            if (this.Handle != IntPtr.Zero)
            {
                Win32.PostMessage(
                        new HandleRef(this, this.Handle),
                        this.runOnUiThreadWindowsMessageNumber,
                        IntPtr.Zero,
                        IntPtr.Zero);
            }
        }
    
        /// <summary>
        /// Returns the handle of the main window menu.
        /// </summary>
        /// <returns>
        /// The handle of the main window menu; Handle <see cref="IntPtr.Zero"/>
        /// on failure.
        /// </returns>
        public HandleRef MenuHandle()
        {
            return new HandleRef(
                    this,
                    this.Handle != IntPtr.Zero
                        ? Win32.GetMenu(new HandleRef(this, this.Handle))
                        : IntPtr.Zero);
        }
    
        /// <summary>
        /// When the instance gets disposed.
        /// </summary>
        public void Dispose()
        {
            this.ReleaseHandle();
        }
    
        /// <summary>
        /// Sets the handle.
        /// </summary>
        /// <param name="handle">
        ///   The handle.
        /// </param>
        /// <param name="onlyIfNotSet">
        /// If true, will not assign to an already assigned handle.
        /// </param>
        public void AssignHandle(IntPtr handle, bool onlyIfNotSet)
        {
            bool emptyBacklog = false;
            lock (this.handleLock)
            {
                if (this.Handle != handle
                        && (!onlyIfNotSet || this.Handle != IntPtr.Zero))
                {
                    base.AssignHandle(handle);
                    emptyBacklog = true;
                }
            }
    
            if (emptyBacklog)
            {
                this.EmptyUiBacklog();
            }
        }
    
        /// <summary>
        /// Adds a message handler for the given message number.
        /// </summary>
        /// <param name="messageNumber">
        /// The message number.
        /// </param>
        /// <param name="messageHandler">
        /// The message handler.
        /// </param>
        public void AddMessageHandler(
            int messageNumber,
            MessageHandler messageHandler)
        {
            lock (this.messageHandlers)
            {
                if (this.messageHandlers.ContainsKey(messageNumber))
                {
                    this.messageHandlers[messageNumber] += messageHandler;
                }
                else
                {
                    this.messageHandlers.Add(
                            messageNumber, (MessageHandler)messageHandler.Clone());
                }
            }
        }
    
        /// <summary>
        /// Processes the window messages.
        /// </summary>
        /// <param name="m">
        /// The m.
        /// </param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == this.runOnUiThreadWindowsMessageNumber && m.Msg != 0)
            {
                for (;;)
                {
                    MethodArgs ma;
                    lock (this.queue)
                    {
                        if (!this.queue.Any())
                        {
                            break;
                        }
    
                        ma = this.queue.Dequeue();
                    }
    
                    ma.Method.DynamicInvoke(ma.Args);
                }
    
                return;
            }
    
            int messageNumber = m.Msg;
            MessageHandler mh;
            if (this.messageHandlers.TryGetValue(messageNumber, out mh))
            {
                if (mh != null)
                {
                    foreach (MessageHandler cb in mh.GetInvocationList())
                    {
                        try
                        {
                            // if WM_DESTROY (messageNumber == 2),
                            // ignore return value
                            if (cb(this, ref m) && messageNumber != 2)
                            {
                                return; // done processing
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(string.Format("{0}", ex));
                        }
                    }
                }
            }
    
            base.WndProc(ref m);
        }
    
        /// <summary>
        /// Empty any existing backlog of things to run on the user interface
        /// thread.
        /// </summary>
        private void EmptyUiBacklog()
        {
            // Check to see if there is a backlog of
            // methods to run on the UI thread. If there
            // is than notify the UI thread about them.
            bool haveBacklog;
            lock (this.queue)
            {
                haveBacklog = this.queue.Any();
            }
    
            if (haveBacklog)
            {
                Win32.PostMessage(
                        new HandleRef(this, this.Handle),
                        this.runOnUiThreadWindowsMessageNumber,
                        IntPtr.Zero,
                        IntPtr.Zero);
            }
        }
    
        /// <summary>
        /// Holds a method and its arguments.
        /// </summary>
        private class MethodArgs
        {
            /// <summary>
            /// Gets or sets the method arguments.
            /// </summary>
            public object[] Args { get; set; }
    
            /// <summary>
            /// Gets or sets Method.
            /// </summary>
            public Delegate Method { get; set; }
        }
    }
