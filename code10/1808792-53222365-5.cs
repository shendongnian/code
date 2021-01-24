    public interface IEventFactory
    {
        IEvent CreateEvent(string someCondition);
    }
    public class EventFactory : IEventFactory
    {
        public IEvent CreateEvent(string someCondition)
        {
            switch(SomeCondition){
                case "FirstCondition":
                    return new EventA();
                case "SecondCondition":
                    return new EventB(); 
                case "ThirdCondition":
                    return new EventC();
                case "FourthCondition":
                    return new EventD();
        }
    }
