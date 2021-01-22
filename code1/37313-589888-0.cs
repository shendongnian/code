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
                delegateApplyTransformation = new DelegateApplyTransformations(adapterTrans.ApplyFullMemoryTransformations);
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
