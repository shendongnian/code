    public class TransformDelegateWithCallBack
    {
        /// <summary>
        /// Delegate which points to AdapterTransform.ApplyFullMemoryTransformations()
        /// </summary>
        /// <param name="filename">Transformation file name</param>
        /// <param name="rawXml">Raw Xml data to be processed</param>
        /// <param name="count">Variable used to keep a track of no of async delegates</param>
        /// <returns>Transformed XML string</returns>
        public delegate string DelegateApplyTransformations(string filename, string rawXml, int count);
        public ArrayList resultArray;
       
        //// Declare async delegate and result
        DelegateApplyTransformations delegateApplyTransformation;
        IAsyncResult result;
        /// <summary>
        /// Constructor to initialize the async delegates, results and handles to the no of tabs in excel
        /// </summary>
        public TransformDelegateWithCallBack()
        {
            resultArray = ArrayList.Synchronized(new ArrayList());
        }
        
        
        /// <summary>
        /// Invoke the async delegates with callback model
        /// </summary>
        /// <param name="filename">Transformation file name</param>
        /// <param name="rawXml">Raw Xml data to be processed</param>
        /// <param name="count">Variable used to keep a track of no of async delegates</param>
        public void CallDelegates(string fileName, string rawXml, int count)
        {
            try
            {
                AdapterTransform adapterTrans = new AdapterTransform();
                // In the below stmt, adapterTrans.ApplyFullMemoryTransformations is the web method being called
                delegateApplyTransformation = new DelegateApplyTransformations(adapterTrans.ApplyFullMemoryTransformations);
                // The below stmt places an async call to the web method
                // Since it is an async operation control flows immediately to the next line eventually coming out of the current method. Hence exceptions in the web service if any will NOT be caught here.
                // CallBackMethod() is the method that will be called automatically after the async operation is done
                // result is an IAsyncResult which will be used in the CallBackMethod to refer to this delegate
                // result gets passed to the CallBackMethod 
                result = delegateApplyTransformation.BeginInvoke(fileName, rawXml, count, new AsyncCallback(CallBackMethod), null);
            }
            catch (CustomException ce)
            {
                throw ce;
            }
        }
        /// <summary>
        /// Callback method for async delegate
        /// </summary>
        /// <param name="o">By default o will always have the corresponding AsyncResult</param>
        public void CallBackMethod(object o)
        {
            try
            {
                AsyncResult asyncResult = (AsyncResult)o;
                // Now when you do an EndInvoke, if the web service has thrown any exceptions, they will be caught
                // resultString is the value the web method has returned. (Return parameter of the web method)
                string resultString = ((DelegateApplyTransformations)asyncResult.AsyncDelegate).EndInvoke((IAsyncResult)asyncResult);
                lock (this.resultArray.SyncRoot)
                {
                    this.resultArray.Add(resultString);
                }
            }
            catch (Exception ex)
            {
                // Handle ex
            }
        }
    }
