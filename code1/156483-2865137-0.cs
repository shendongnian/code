    private void startJob(object work) {
        Thread t = new Thread(
          new System.Threading.ParameterizedThreadStart(methodToCall)
        );
        t.IsBackground = true; // if you set this, it will exit if all main threads exit.
        t.Start(work); // this launches the methodToCall in its own thread.
    }
    private void methodToCall(object work) {
        // do the stuff you want to do
        updateGUI(result);
    }
    private void updateGUI(object result) {
        if (InvokeRequired) {
            // C# doesn't like cross thread GUI operations, so queue it to the GUI thread
            Invoke(new Action<object>(updateGUI), result);
            return;
        }
        // now we are "back" in the GUI operational thread.
        // update any controls you like.
    }
