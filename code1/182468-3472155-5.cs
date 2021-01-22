    private void CallOnTheUiThread(object dataToPassToUiThread)
    {
        // Make sure the code is run on the provided thread context.
        // Make the calling thread wait for completion by calling Send, not Post.
        mContext.Send(state =>
            {
                // Change your UI here using dataToPassToUiThread.  
                // Since this class is not on a form, you probably would 
                // raise an event with the data.
            }
        ), null);
    }
