        private void AcceptCallbackWithSyncCheck(IAsyncResult asyncResult)
        {
            if (asyncResult.CompletedSynchronously)
            {
                // Force the accept logic to run async, to keep our listening
                // thread free.
                Action accept = () => this.ActualAcceptCallback(asyncResult);
                accept.BeginInvoke(accept.EndInvoke, null);
            }
            else
            {
                this.ActualAcceptCallback(asyncResult);
            }
        }
