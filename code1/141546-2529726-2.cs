    public class MyForm : Form
    {
        private AutoResetEvent continueEvent = new AutoResetEvent(false);
        // Previous BackgroundWorker code would go here
        private void ExecuteRecursiveOperation(MyTreeNode node)
        {
            if (bwRecursive.CancellationPending)
                return;
            foreach (MyTreeNode childNode in node.ChildNodes)
            {
                continueEvent.WaitOne();  // <--- This is the new code
                if (bwRecursive.CancellationPending)
                    break;
                ExecuteRecursiveOperation(childNode);
            }
        }
        private void btnContinue_Click(object sender, EventArgs e)
        {
            continueEvent.Set();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            bwRecursive.CancelAsync();
            continueEvent.Set();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            continueEvent.Set();
            bwRecursive.RunWorkerAsync(...);
        }
    }
