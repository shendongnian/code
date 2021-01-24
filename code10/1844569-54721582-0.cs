    public class BaseEvent { }
    public class DerivedEvent1 : BaseEvent { }
    public class DerivedEvent2 : BaseEvent { }
    
    public interface IEvent
    {
        void Subscribe<T>() where T : BaseEvent;
    }
    var eventMock = new Mock<IEvent>();
    eventMock.Object.Subscribe<DerivedEvent1>();
    eventMock.Object.Subscribe<DerivedEvent2>();
    eventMock.Verify(m => m.Subscribe<BaseEvent>(), Times.Exactly(2));
