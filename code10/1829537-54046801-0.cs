        protected override IAsyncResult BeginInvokeActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor,
            IDictionary<string, object> parameters, AsyncCallback callback, object state)
        {
            // Initiate the asychronous call.
            var asyncResult = yourMethod.BeginInvoke(<your params>);
            // Wait for the WaitHandle to become signaled.
            asyncResult.AsyncWaitHandle.WaitOne();
            // Perform additional processing here.
            // Call EndInvoke to retrieve the results.
            var returnObject = yourMethod.EndInvoke(asyncResult);
            asyncResult.AsyncWaitHandle.Close();
            return base.BeginInvokeActionMethod(controllerContext, actionDescriptor, parameters, callback, state);
        }
