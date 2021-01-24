    public interface IDomainEvent
    {
        DateTime OccurredOn { get; set; }
        Guid MessageId { get; set; }
    }
    public class TestUserCreated : IDomainEvent
    {
        // id can be accessed by whatever needs it by being
        // defined explicity within the domain event POCO
        // without needing any base class or framework.
        public readonly TestUserId Id;
        public readonly string Name;
        public TestUserCreated(TestUserId id, string name)
        {
             Id = id;
             Name = name;
        }        
    }
