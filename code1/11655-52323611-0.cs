    class DisposeSample : IDisposable
    {
        DataSet myDataSet = new DataSet();
        private bool _isDisposed;
        public DisposeSample()
        {
            // attach dispose event for myDataSet
            myDataSet.Disposed += MyDataSet_Disposed;
        }
        private void MyDataSet_Disposed(object sender, EventArgs e)
        {
            //Event triggers when myDataSet is disposed
            _isDisposed = true; // set private bool variable as true 
        }
        public void Dispose()
        {
            if (!_isDisposed) // only dispose if has not been disposed;
                myDataSet?.Dispose(); // only dispose if myDataSet is not null;
        }
    }
