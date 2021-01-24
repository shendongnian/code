    public class SomeService {
        private readonly IEventBus eventBus;
    
        public SomeService(IEventBus eventBus) {
            this.eventBus = eventBus;
        }
    
        public SomeAction() {
            if (eventBus != null) {
                eventBus.publish("SomeAction Happened!");
            }
            //...
        }
    }
