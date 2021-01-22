        public void OnIncomingCall(Call call, CallState callState, 
           CallInfoState callInfoState)
        {
            // See if this call is on our list of approved callers
            HandleIncomingCall(call.CallerID);
        }
        public void HandleIncomingCall(string callNumber)
        {
            bool callApproved = false;
            foreach (PhoneContact phoneContact in Whitelist)
            {
                if (phoneContact.PhoneNumber == callNumber)
                    callApproved = true;
            }
            // If this is not an approved call then 
            if (!callApproved)
                CallMonitor.Hangup();
        }
