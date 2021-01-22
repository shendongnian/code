    public virtual void SignalFromCurrentContext(Exception e)
    {
        if (HttpContext.Current != null)
            Elmah.ErrorSignal.FromCurrentContext().Raise(e);
    }
}
