    if (mImageListView != null && 
        mImageListView.IsHandleCreated &&
        !mImageListView.IsDisposed)
    {
        m.WaitOne(); 
        if (mImageListView.InvokeRequired)
            mImageListView.Invoke(
                new RefreshDelegateInternal(mImageListView.RefreshInternal));
        else
            mImageListView.RefreshInternal();
        
        m.ReleaseMutex();
    }
