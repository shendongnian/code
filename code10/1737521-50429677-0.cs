    public class SomeService {
       private readonly IEventBus _bus;
       public SomeService(IEventBus bus) {
          _bus = bus ?? throw new ArgumentNullException(nameof(bus));
       }
       public SomeAction() {
           eventBus.publish("SomeAction Happened!");
       }
    }
