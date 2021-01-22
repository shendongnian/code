    Subscriber subscriber = new Subscriber { SubscriberID = 1};
    AddOn newAddOn = new AddOn { AddOnID = 5};
    using (var context = new TestEntities())
    {
        
        context.AttachTo("Subscriber", subscriber);
        subscriber.Addon.Add(newAddOn);
        subscriber.Name = "dummy";
        context.SaveChanges();
    }
