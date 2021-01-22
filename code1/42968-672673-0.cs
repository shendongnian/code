        public static void ClearMouseClickQueue()
        {
            Message message;
            while (PeekMessage(out message,IntPtr.Zero, (uint) MessageCodes.WM_MOUSEFIRST,(uint) MessageCodes.WM_MOUSELAST,1) != 0)
            {    
            }
        }
        private object approvalLockObject = new object();
        private void btnApproveTransaction_Click(object sender, EventArgs e)
        {
            ApproveTransactionAndLockForm();
        }
        private void ApproveTransactionAndLockForm()
        {
            lock (approvalLockObject)
            {
                if (ApprovalLockCount == 0)
                {
                    ApprovalLockCount++;
                    ApproveTransaction();
                }
                else
                {
                    CloseAndRetry();
                }
            }
        }
        private void ApproveTransaction()
        {
            ClearMouseClickQueue();
            this.Enabled = false;
            Logger.LogInfo("Before approve transaction");
            MouseHelper.SetCursorToWaitCursor();
            ... validate invoice and print
        }
            
