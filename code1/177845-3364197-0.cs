    class MyClass {
        private LinkedList<MyEventHandler> eventHandlers;
        public enum Ordering { First, Last, ... };
        public void AddHandler(MyEventHandler handler, Ordering order) {
            switch(order) {
                case Ordering.First:
                    eventHandlers.AddFirst(handler);
                    break;
                // fill in other cases here...
            }
        }
        public void RaiseEvent() {
            // call handlers in order
            foreach(MyEventHandler handler in eventHandlers)
                eventHandler();
        }
    }
