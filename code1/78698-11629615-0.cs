    //EVENT DRIVEN OBSERVER PATTERN
    public class Publisher
    {
        public Publisher()
        {
            var observable = new Observable();
            observable.PublishData("Hello World!");
        }
    }
    //Server will send data to this class's PublishData method
    public class Observable
    {
        public event Receive OnReceive;
        public void PublishData(string data)
        {
            //Add all the observer below
            //1st observer
            IObserver iObserver = new Observer1();
            this.OnReceive += iObserver.ReceiveData;
            //2nd observer
            IObserver iObserver2 = new Observer2();
            this.OnReceive += iObserver2.ReceiveData;
            //publish data 
            var handler = OnReceive;
            if (handler != null)
            {
                handler(data);
            }
        }
    }
    public interface IObserver
    {
        void ReceiveData(string data);
    }
    //Observer example
    public class Observer1 : IObserver
    {
        public void ReceiveData(string data)
        {
            //sample observers does nothing with data :)
        }
    }
    public class Observer2 : IObserver
    {
        public void ReceiveData(string data)
        {
            //sample observers does nothing with data :)
        }
    }
