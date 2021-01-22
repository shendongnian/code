    public void SomeMethodInYourViewModel()
    {
        try
        {
            DoSomethingDangerous();
        }
        catch (Exception ex)
        {
            ServiceLocator.Resolve<IMessageService>().ShowMessage(ex.Message);
        }
    }
