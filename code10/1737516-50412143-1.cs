    public SomeAction(IEventBus eventBus = null) {
        if (eventBus != null) {
            eventBus.publish("SomeAction Happened!");
        }
        //...
    }
