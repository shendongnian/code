    public void Initialize()
    {
    	m_ancSubscriberWrapper.UnshownNotificationCounterUpdated += OnUnshownNotificationCounterUpdated;
    }
    
    public void Teardown()
    {
    	m_ancSubscriberWrapper.UnshownNotificationCounterUpdated -= OnUnshownNotificationCounterUpdated;
    }
