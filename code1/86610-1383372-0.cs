    delegate void SimpleInvokeDelegate();
    private void SampleMethod()
    {
        if (InvokeRequired)
        {
            Invoke(new SimpleInvokeDelegate(SampleMethod));
        }
        else
        {
           // Update UI elements here.
        }
    }
