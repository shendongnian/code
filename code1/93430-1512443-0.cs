    AddOn newAddOn = new AddOn { AddOnID = 5};
    AddOn oldAddOn = new AddOn { AddOnID = 4}; // you need to remember the old id.
    Subscriber subscriber = new Subscriber { SubscriberID = 1, AddOn = oldAddOn};
    
    using (var context = new TestEntities())
    {
        context.AttachTo("AddOn", newAddOn);
        context.AttachTo("Subscriber", subscriber); // will attach the oldAddOn too
    
        subscriber.Name = "dummy";
        subscriber.AddOn = newAddOn;
    
        context.SaveChanges();
    }
