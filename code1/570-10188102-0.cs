    private void Reset()
    {
        if(_dataset != null)
        {
           _dataset.Dispose();
           _dataset = null;
        }
        //..More such member variables like oracle connection etc. _oraConnection
     }
