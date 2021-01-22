    private void HookUpEvents()
    {
      Type purchaseOrderType = typeof (PurchaseOrder);
      var events = purchaseOrderType.GetEvents();
      foreach (EventInfo info in events)
      {
        if (info.EventHandlerType == typeof(Kctc.Data.Domain.DomainObject.InvalidDomainObjectEventHandler))
        {
          info.AddEventHandler(_purchaseOrder, new Kctc.Data.Domain.DomainObject.InvalidDomainObjectEventHandler(HandleDomainObjectEvent));
        }
      }
    }
