    public class StringWriter : IObserver<String>
    {
        public void OnNext(string value)
        {
            Console.WriteLine("Do returned " + value);
        }
        // and the other IObserver<String> methods
    }
    var subscriber = myFooInstance.DoValues.Subscribe(new StringWriter());
    // from now on, anytime myFooInstance.Do() is called, the value it 
    // returns will be written to the console by the StringWriter observer.
