    ISaveOrUpdateEventListener[] saveUpdateListeners = new ISaveOrUpdateEventListener[] { new AuditableEventListener() };
    conf.EventListeners.SaveEventListeners = saveUpdateListeners;
    conf.EventListeners.SaveOrUpdateEventListeners = saveUpdateListeners;
    conf.EventListeners.UpdateEventListeners = saveUpdateListeners;
    
    conf.EventListeners.PreUpdateEventListeners = new IPreUpdateEventListener[] { new AuditableEventListener() };
