    class Program
    {
        static void Main(string[] args)
        {
            var channel = GenerateMsgs()
                .Where(m => m.process)
                .Subscribe((MyMessage m) => Console.WriteLine(m.subject));
        }
		
		public IObservable<MyMessage> GenerateMsgs()
		{
			return Observable.Create<MyMessage>(observer=>
			{
				observer.OnNext(new MyMessage() {subject = "Hello!", process = true});
			});
		}
    }
    public class MyMessage
    {
        public string subject;
        public bool process;
    }
