     // Delegate for marshalling the call on the correct thread.
        private delegate void SetIdleStateDelegate(string callStatusMsg);
        // Set object back to idle state.
        public void SetIdleState(string callStatusMsg)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new SetIdleStateDelegate(SetIdleState), callStatusMsg);
            }
            else
            {
                this.btnCallAnswer.Text = CATWinSIP_MsgStrings.Call;
                this.btnEndCallReject.Text = CATWinSIP_MsgStrings.EndCall;
                this.btnHoldUnhold.Text = CATWinSIP_MsgStrings.Hold;
                this.btnCallAnswer.Enabled = true;
                this.btnRedial.Enabled = true;
                this.btnEndCallReject.Enabled = false;
                this.btnHoldUnhold.Enabled = false;
            }           
        }      
