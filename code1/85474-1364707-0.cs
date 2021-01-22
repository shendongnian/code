		public static IAsyncResult SafeBeginInvoke(this Control control, Delegate method, params object[] parameters)
		{
			return (IAsyncResult)SafeInvoke(control, method, false, parameters);
		}
		public static object SafeInvoke(this Control control, Delegate method, params object[] parameters)
		{
			return SafeInvoke(control, method, true, parameters);
		}
		private delegate object SafeInvokeCallback(Control control, Delegate method, bool forceSynchronous, params object[] parameters);
		public static object SafeInvoke(this Control control, Delegate method, bool forceSynchronous, params object[] parameters)
		{
			if (control == null)
			{
				throw new ArgumentNullException("control");
			}
			if (control.InvokeRequired)
			{
				IAsyncResult result = null;
				try
				{
					result = control.BeginInvoke(new SafeInvokeCallback(SafeInvoke), control, method, forceSynchronous, parameters);
				}
				catch (InvalidOperationException)
				{
					//This control has not been created or was already (more likely) closed. 
				}
				if (forceSynchronous && result != null)
					return control.EndInvoke(result);
				else
					return result;
			}
			else
			{
				if (!control.IsDisposed)
					return method.DynamicInvoke(parameters);
			}
			return null;
		}
