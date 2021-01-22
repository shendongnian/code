    @FunctionalInterface
    public interface IEvent<TEventArgs extends Object> {
        void invoke(TEventArgs eventArgs);
    }
    
    public class EventHandler<TEventArgs>
    {
        private ArrayList<IEvent<TEventArgs>> eventDelegateArray = new ArrayList<>();
        public void subscribe(IEvent<TEventArgs> methodReference)
        {
            eventDelegateArray.add(methodReference);
        }
        public void unSubscribe(IEvent<TEventArgs> methodReference)
        {
            eventDelegateArray.remove(methodReference);
        }
        public void invoke(TEventArgs eventArgs)
        {
            if (eventDelegateArray.size()>0)
                eventDelegateArray.forEach(p -> p.invoke(eventArgs));
        }
    }
    
    public class DummyEventProducer
    {
        // The event
        public EventHandler<String> myEvent = new EventHandler<>();
    
        public void onMyEvent(String A)
        {
            myEvent.invoke(A);
        }
    }
    
    
    public class DummySubscriber {
    
        // The method will be subscribed to the event
        public void methodCallWhenEventGetTriggered(String eventArgs)
        {
            System.out.println("event fired with eventargs: " + eventArgs);
        }
    }
    
    
    public class Main {
    
        public static void main(String[] args)
        {
            // A dummy producer
            DummyEventProducer producer = new DummyEventProducer();
    
            // A dummy subscribers
            DummySubscriber testingInstanceA = new DummySubscriber();
            DummySubscriber testingInstanceB = new DummySubscriber();
            DummySubscriber testingInstanceC = new DummySubscriber();
    
            // We create decoupled event links because we want to un-subscribe later
            IEvent<String> EventSink1 = testingInstanceA::methodCallWhenEventGetTriggered;
            IEvent<String> EventSink2 = testingInstanceB::methodCallWhenEventGetTriggered;
            IEvent<String> EventSink3 = testingInstanceC::methodCallWhenEventGetTriggered;
    
            // subscribe to the event on dummy producer
            producer.myEvent.subscribe(EventSink1);
            producer.myEvent.subscribe(EventSink2);
            producer.myEvent.subscribe(EventSink3);
    
            // fire the event on producer
            producer.onMyEvent("Hola MUNDO with decoupled subscriptions!");
    
            // unsubscribe to the event on dummy producer
            producer.myEvent.unSubscribe(EventSink1);
            producer.myEvent.unSubscribe(EventSink2);
            producer.myEvent.unSubscribe(EventSink3);
    
            // fire the event on producer again
            producer.onMyEvent("Hola MUNDO! with no events subscriptions :(");
    
            // IF YOU DON CARE ABOUT UNSUBSCRIBE YOU CAN LINK EVENTS DIRECTLY TO THE SUBSCRIBER
            producer.myEvent.subscribe(testingInstanceA::methodCallWhenEventGetTriggered);
            producer.myEvent.subscribe(testingInstanceB::methodCallWhenEventGetTriggered);
            producer.myEvent.subscribe(testingInstanceC::methodCallWhenEventGetTriggered);
    
            // fire the event on producer again
            producer.onMyEvent("Hola MUNDO! with strong link subscriptions (cannot be un-subscribed");
        }
    }
