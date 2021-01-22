        public void Trigger(bool suppressSelfHandler = false)
        {
            bool modifiedList = false;
            // The finally block is a ConstrainedExecutionRegion... we definitely don't want to
            // deadlock the whole shared event because we crashed while holding the lock.
            RuntimeHelpers.PrepareConstrainedRegions();
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
                    Semaphore handle = null;
                    try
                    {
                        handle = GetListenerWaitHandle( memberId, false );
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
                            i++;
                        }
                    }
                    finally
                    {
                        handle?.Dispose();
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
