    // Lives in AssemblyA
    public class ExistingEvent : IEvent
    {
    }
    // Lives in AssemblyB that has a dependency on both
    // AssemblyA and MediatR
    public class MediatrExistingEvent : ExistingEvent, IEvent
    {
    }
