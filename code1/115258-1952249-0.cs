    class MyForm: Form
    {
        private void delegate UpdateDelegate(int Progress);
        private void UpdateProgress(int Progress)
        {
            if ( this.InvokeRequired )
                this.Invoke((UpdateDelegate)UpdateProgress, Progress);
            else
                this.MyProgressBar.Progress = Progress;
        }
    }
