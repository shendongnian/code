	/// <summary>
	/// Provies a wrapper type around event handlers for a control that are safe to be
	/// used from events on another thread.  If the control is not valid at the time the
	/// delegate is called an exception of type ObjectDisposedExcpetion will be raised.
	/// </summary>
	[System.Diagnostics.DebuggerNonUserCode]
	public class EventHandlerForControl<TEventArgs> where TEventArgs : EventArgs
	{
		/// <summary> The control who's thread we will use for the invoke </summary>
		protected readonly Control _control;
		/// <summary> The delegate to invoke on the control </summary>
		protected readonly EventHandler<TEventArgs> _delegate;
		/// <summary>
		/// Constructs an EventHandler for the specified method on the given control instance.
		/// </summary>
		public EventHandlerForControl(Control control, EventHandler<TEventArgs> handler)
		{
			if (control == null) throw new ArgumentNullException("control");
			_control = control.TopLevelControl;
			if (handler == null) throw new ArgumentNullException("handler");
			_delegate = handler;
		}
		/// <summary>
		/// Constructs an EventHandler for the specified delegate converting it to the expected
		/// EventHandler&lt;TEventArgs> delegate type.
		/// </summary>
		public EventHandlerForControl(Control control, Delegate handler)
		{
			if (control == null) throw new ArgumentNullException("control");
			_control = control.TopLevelControl;
			if (handler == null) throw new ArgumentNullException("handler");
			//_delegate = handler.Convert<EventHandler<TEventArgs>>();
			_delegate = handler as EventHandler<TEventArgs>;
			if (_delegate == null)
			{
				foreach (Delegate d in handler.GetInvocationList())
				{
					_delegate = (EventHandler<TEventArgs>) Delegate.Combine(_delegate,
						Delegate.CreateDelegate(typeof(EventHandler<TEventArgs>), d.Target, d.Method, true)
					);
				}
			}
			if (_delegate == null) throw new ArgumentNullException("_delegate");
		}
		/// <summary>
		/// Used to handle the condition that a control's handle is not currently available.  This
		/// can either be before construction or after being disposed.
		/// </summary>
		protected virtual void OnControlDisposed(object sender, TEventArgs args)
		{
			throw new ObjectDisposedException(_control.GetType().Name);
		}
		/// <summary>
		/// This object will allow an implicit cast to the EventHandler&lt;T> type for easier use.
		/// </summary>
		public static implicit operator EventHandler<TEventArgs>(EventHandlerForControl<TEventArgs> instance)
		{ return instance.EventHandler; }
		/// <summary>
		/// Handles the 'magic' of safely invoking the delegate on the control without producing
		/// a dead-lock.
		/// </summary>
		public void EventHandler(object sender, TEventArgs args)
		{
			bool requiresInvoke = false, hasHandle = false;
			try
			{
				lock (_control) // locked to avoid conflicts with RecreateHandle and DestroyHandle
				{
					if (true == (hasHandle = _control.IsHandleCreated))
					{
						requiresInvoke = _control.InvokeRequired;
						// must remain true for InvokeRequired to be dependable
						hasHandle &= _control.IsHandleCreated;
					}
				}
			}
			catch (ObjectDisposedException)
			{
				requiresInvoke = hasHandle = false;
			}
			if (!requiresInvoke && hasHandle) // control is from the current thread
			{
				_delegate(sender, args);
				return;
			}
			else if (hasHandle) // control invoke *might* work
			{
				MethodInvokerImpl invocation = new MethodInvokerImpl(_delegate, sender, args);
				IAsyncResult result = null;
				try
				{
					lock (_control)// locked to avoid conflicts with RecreateHandle and DestroyHandle
						result = _control.BeginInvoke(invocation.Invoker);
				}
				catch (InvalidOperationException)
				{ }
				try
				{
					if (result != null)
					{
						WaitHandle handle = result.AsyncWaitHandle;
						TimeSpan interval = TimeSpan.FromSeconds(1);
						bool complete = false;
						while (!complete && (invocation.MethodRunning || _control.IsHandleCreated))
						{
							if (invocation.MethodRunning)
								complete = handle.WaitOne();//no need to continue polling once running
							else
								complete = handle.WaitOne(interval);
						}
						if (complete)
						{
							_control.EndInvoke(result);
							return;
						}
					}
				}
				catch (ObjectDisposedException ode)
				{
					if (ode.ObjectName != _control.GetType().Name)
						throw;// *likely* from some other source...
				}
			}
			OnControlDisposed(sender, args);
		}
		/// <summary>
		/// The class is used to take advantage of a special-case in the Control.InvokeMarshaledCallbackDo()
		/// implementation that allows us to preserve the exception types that are thrown rather than doing
		/// a delegate.DynamicInvoke();
		/// </summary>
		[System.Diagnostics.DebuggerNonUserCode]
		private class MethodInvokerImpl
		{
			readonly EventHandler<TEventArgs> _handler;
			readonly object _sender;
			readonly TEventArgs _args;
			private bool _received;
			public MethodInvokerImpl(EventHandler<TEventArgs> handler, object sender, TEventArgs args)
			{
				_received = false;
				_handler = handler;
				_sender = sender;
				_args = args;
			}
			public MethodInvoker Invoker { get { return this.Invoke; } }
			private void Invoke() { _received = true; _handler(_sender, _args); }
			public bool MethodRunning { get { return _received; } }
		}
	}
