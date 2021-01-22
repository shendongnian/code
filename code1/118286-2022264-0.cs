    public delegate void CallbackInvoker(Delegate method, params object[] args);
    public YourComponent(CallbackInvoker invoker)
    {
        m_invoker = invoker;
    }
    protected void RaiseEvent(Delegate eventDelegate, object[] args)
    {
        if (eventDelegate != null)
        {
            try
            {
                if (m_invoker != null)
                    m_invoker(eventDelegate, args);
                else
                    eventDelegate.DynamicInvoke(args);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType());
                Console.WriteLine(ex.Message);
                //Swallow
            }
        }
    }
