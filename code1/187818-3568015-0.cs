    public static class ControlExtension
    {
        // --- Static Fields ---
        static bool _fieldsInitialized = false;
        static InvokeDelegateDelegate _methodInvokeDelegate;  // Initialized lazily to reduce application startup overhead [see method: InitStaticFields]
        static InvokeMethodDelegate _methodInvokeMethod;  // Initialized lazily to reduce application startup overhead [see method: InitStaticFields]
    
        // --- Public Static Methods ---
        public static bool TryBeginInvoke(this Control control, Delegate method, params object[] args)
        {
            IAsyncResult asyncResult;
            return TryBeginInvoke(control, method, out asyncResult, args);
        }
    
        /// <remarks>May return true even if the target of the invocation cannot execute due to being disposed during invocation.</remarks>
        public static bool TryBeginInvoke(this Control control, Delegate method, out IAsyncResult asyncResult, params object[] args)
        {
            if (!_fieldsInitialized)
                InitStaticFields();
    
            asyncResult = null;
    
            if (!control.IsHandleCreated || control.IsDisposed)
                return false;
    
            try
            {
                control.BeginInvoke(_methodInvokeDelegate, control, method, args);
            }
            catch (ObjectDisposedException)
            {
                return false;
            }
            catch (InvalidOperationException)  // Handle not created
            {
                return false;
            }
    
            return true;
        }
    
        public static bool TryBeginInvoke(this Control control, MethodInvoker method)
        {
            IAsyncResult asyncResult;
            return TryBeginInvoke(control, method, out asyncResult);
        }
    
        /// <remarks>May return true even if the target of the invocation cannot execute due to being disposed during invocation.</remarks>
        public static bool TryBeginInvoke(this Control control, MethodInvoker method, out IAsyncResult asyncResult)
        {
            if (!_fieldsInitialized)
                InitStaticFields();
    
            asyncResult = null;
    
            if (!control.IsHandleCreated || control.IsDisposed)
                return false;
    
            try
            {
                control.BeginInvoke(_methodInvokeMethod, control, method);
            }
            catch (ObjectDisposedException)
            {
                return false;
            }
            catch (InvalidOperationException)  // Handle not created
            {
                return false;
            }
    
            return true;
        }
    
        // --- Private Static Methods ---
        private static void InitStaticFields()
        {
            _methodInvokeDelegate = new InvokeDelegateDelegate(InvokeDelegate);
            _methodInvokeMethod = new InvokeMethodDelegate(InvokeMethod);
        }
        private static object InvokeDelegate(Control control, Delegate method, object[] args)
        {
            if (!control.IsHandleCreated || control.IsDisposed)
                return null;
    
            return method.DynamicInvoke(args);
        }
        private static void InvokeMethod(Control control, MethodInvoker method)
        {
            if (!control.IsHandleCreated || control.IsDisposed)
                return;
    
            method();
        }
    
        // --- Private Nested Types ---
        delegate object InvokeDelegateDelegate(Control control, Delegate method, object[] args);
        delegate void InvokeMethodDelegate(Control control, MethodInvoker method);
    }
