        public void Trigger(bool suppressSelfHandler = false)
        {
            bool modifiedList = false;
            this.registrationLock.WaitOne();
            try
            {
                List<int> ids = ReadListenerIds();
                for( int i = 0; i < ids.Count; /* conditional increment */ )
                {
                    int memberId = ids[i];
                    if( suppressSelfHandler && memberId == this.localWaitHandleId )
                    {
                        i++;
                        continue;
                    }
                    var handle = GetListenerWaitHandle( memberId, false );
                    if( handle == null )
                    {
                        // The listener's wait handle is gone. This means that the listener died
                        // without unregistering themselves.
                        ids.RemoveAt( i );
                        modifiedList = true;
                    }
                    else
                    {
                        handle.Release();
                        handle.Dispose();
                        handle = null;
                        i++;
                    }
                }
                if( modifiedList )
                {
                    WriteListenerIds( ids );
                }
            }
            finally
            {
                this.registrationLock.Release();
            }
        }
