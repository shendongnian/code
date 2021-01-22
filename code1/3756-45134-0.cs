        protected override void OnSessionChange(SessionChangeDescription changeDescription)
        {
            if (changeDescription.Reason == SessionChangeReason.SessionLock)
            { 
                //I left my desk
            }
            else if (changeDescription.Reason == SessionChangeReason.SessionUnlock)
            { 
                //I returned to my desk
            }
        }
