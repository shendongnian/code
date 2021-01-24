    public void Test()
    {
        try
        {
            Func<int> d = () => 0;
            Action a = () => { String.Format("{0}", 1 / d()); };
            a();
        }
        catch (Exception ex)
        {
            var useful = ex.TryGetExceptionOrigin(null, null, 0);
        }
    }       
