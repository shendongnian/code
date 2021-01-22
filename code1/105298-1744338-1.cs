    using (Recorder recorder = Recorder.StartNew())
    {
        try
        {
            DoSomeWork();
        }
        catch (Exception ex)
        {
            recorder.ReportFailure(ex);
        }
    }
