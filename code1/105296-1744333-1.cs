    public void Record(Action act)
    {
        try
        {
            this.StartTiming();
            act();
        }
        catch(Exception ex)
        {
            this.ReportFailure(ex);
        }
        finally
        {
            this.Stop();
        }
    }
