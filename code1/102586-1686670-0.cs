    public class RequestTracker
    {   
        private Hashtable hash;
        private Hashtable hashSync;
        public RequestTracker() {
            hash = new Hashtable();
            hashSync = Hashtable.Synchronized(hash);
        }
        public int UpdateRequestId() {
            if (CwGlobal.SessionIdExists)
            {
                int newRequestId = hashSync.ContainsKey(CwGlobal.SessionId) ? (int)hashSync[CwGlobal.SessionId] + 1 : 1;
                hashSync[CwGlobal.SessionId] = newRequestId;
                return newRequestId;
            }
            return 0;
        }
        public int CurrentRequestId() {
            if(CwGlobal.SessionIdExists && hashSync.ContainsKey(CwGlobal.SessionId))
                return (int)hashSync[CwGlobal.SessionId];
            return 0;
        }
    }
