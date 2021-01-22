        // private readonly Action _actionSetVisibleByAction
        // _actionSetVisibleByAction= SetVisibleByAction;
        private void SetVisibleByAction()
        {
            if (InvokeRequired)
            {
                Invoke(_actionSetVisibleByAction);
            }
            else
            {
                Visible = true;
            }
        }
