        private delegate void InvokeAction();
        private void DoUI(InvokeAction call) {
            if (IsDisposed) {
                return;
            }
            if (InvokeRequired) {
                try {
                    Invoke(call);
                } catch (InvalidOperationException) {
                    // Handle error
                }
            } else {
                call();
            }
        }
