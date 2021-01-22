    public void InsertStockPrice(double value, string company)
    {
        if (InvokeRequired)
        {
            MethodInvoker invoker = delegate { InsertStockPrice(value, company); }
            Invoke(invoker);
        }
        else
        {
            // Do stuff
        }
    }
