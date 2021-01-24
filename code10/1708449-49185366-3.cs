    bool keepTrying = true;
    while (keepTrying)
    {
        try
        {
            this.UpdateFields();
        }
        catch (Exception e)
        {
            // Either log the error or set keepTrying = false to stop trying
        }
    }
