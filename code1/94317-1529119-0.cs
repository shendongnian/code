    public virtual override void Publish(TPayload payload)
    {
         ILoggerFacade logger = ServiceLocator.Current.GetInstance<ILoggerFacade>();
         logger.Log("Publishing " + payload.ToString(), Category.Debug, Priority.Low);
         base.InternalPublish(payload);
    }
