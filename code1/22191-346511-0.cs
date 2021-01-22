public void DoSomethingInTheBackground()
{
    using (StatusNotification sn = new StatusNotification(this.WorkItem))
    {
        sn.Message("Loading customer data...", 33);
        // Block while loading the customer data....
        sn.Message("Loading order history...", 66);
        // Block while loading the order history...
        sn.Message("Done!", 100);
    }
}
