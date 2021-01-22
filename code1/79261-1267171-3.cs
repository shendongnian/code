    public static YourResultClass DoModal()
    {
        using (TestForm form = new TestForm())
        if (DislogResult.OK == form.ShowDialog())
        {
            YourResultClass result = new YourResultClass();
            // Here initialize YourResultClass instance with data from form instance
            return result;
        }
    }
