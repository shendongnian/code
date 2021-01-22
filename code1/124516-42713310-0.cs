        private void OnCheckedIn(object sender, Session e)
        {
            EventHandler<Session> nextInLine = null; 
            lock (_syncLock)
            {
                if (SessionCheckedIn != null)
                {
                    nextInLine = (EventHandler<Session>)SessionCheckedIn.GetInvocationList()[0];
                    SessionCheckedIn -= nextInLine;
                }
            }
            if ( nextInLine != null )
            {
                nextInLine(this, e);
            }
        }
