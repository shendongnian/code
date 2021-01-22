        public class LongOperationService:ILongOperationService
        {
            ILongOperationCallBack clientCallBackProxy;
            public ILongOperationCallBack ClientCallBackProxy
            {
                get
                {
                    return OperationContext.Current.GetCallbackChannel<ITrialServiceCallBack>());
                }
            }
        
            public bool StartLongOperation(....)
            {
                if(!server.IsBusy)
                {
                     //set server busy state
                    //**Important get the client call back proxy here and save it in a class field.**
                    this.clientCallBackProxy=ClientCallBackProxy;
                    //start long operation in any asynchronous way
                    ......LongOperationWorkAsync(....)
                    return true; //return inmediately
                }
                else return false;
            }
            private void LongOperationWorkAsync(.....)
            {
                .... do work...
                //send results when finished using the cached client call back proxy
                this.clientCallBackProxy.SendResults(....);
                //clear server busy state
            }
            ....
        }
