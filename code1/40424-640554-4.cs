    public class SubscriptionMap : AuditableClassMap<Subscription>
    {
        public SubscriptionMap()
        {
            WithTable("Subscriptions");
            Id(x => x.Id, "Subscriptions");
			
            AddPart(new FreeSubscriptionMap());
            AddPart(new DigitalFreeSubscriptionMap());
            // More sublass mappings and then the field mappings
