      public class ProcessCancelEventWrapper
        {
            public event delProcessCancel ProcessCancelListeners;
    
            public ProcessCancelEventWrapper(delProcessCancel _delProcessCancel)
            {
                ProcessCancelListeners += _delProcessCancel;
            }
    
            public void Raise(string algoIdent, string callBackMessage)
            {
                ProcessCancelListeners(algoIdent, callBackMessage);
            }
        }
    
        public delegate void delProcessCancel(string algoIdent,  string callBackMessage);
        
        public Dictionary<string, ProcessCancelEventWrapper> ProcessCancelListenerDict = new Dictionary<string, ProcessCancelEventWrapper>();
    
    
        public enum ListenerOption { Add, Delete, };
        public void ManageProcessCancelListener(string algoIdent, delProcessCancel _delProcessCancel, ListenerOption listenerOption)
        {
            if (listenerOption==ListenerOption.Add)
            {
                if (!ProcessCancelListenerDict.ContainsKey(algoIdent))
                {
                    ProcessCancelListenerDict.Add(algoIdent, new ProcessCancelEventWrapper(_delProcessCancel));
                }
                else
                {
                    ProcessCancelListenerDict[algoIdent].ProcessCancelListeners += _delProcessCancel;
                }                
            }
            else if (listenerOption == ListenerOption.Delete)
            {
                if (!ProcessCancelListenerDict.ContainsKey(algoIdent))
                {
                }
                else
                {
                    ProcessCancelListenerDict[algoIdent].ProcessCancelListeners -= _delProcessCancel;
                }
            }
    
        }
    
        public void RaiseProcessCancelListener(string algoIdent, string callBackMessage)
        {
            if (!ProcessCancelListenerDict.ContainsKey(algoIdent))
            {
            }
            else
            {
                ProcessCancelListenerDict[algoIdent].Raise(algoIdent, callBackMessage);
            }
        }
