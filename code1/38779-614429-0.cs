     class Program
      {
        static void Main(string[] args)
        {
          // Create publisher.
          var pub = Activator.CreateInstance(typeof(Publisher));
          // Get the event.
          var addEvent = typeof(Publisher).GetEvent("Event");
          // Create subscriber.
          var sub = Activator.CreateInstance(typeof(Subscriber));
          // Get the method.
          var handler = typeof(Subscriber).GetMethod("Handle");
          // Create a valid delegate for it.
          var handlerDelegate = MakeEventHandlerDelegate(handler, sub);
          // Add the event.
          addEvent.AddEventHandler(pub, handlerDelegate);
          // Call the raise method.
          var raise = typeof(Publisher).GetMethod("Raise");
          raise.Invoke(pub, new object[] { "Test Value" });
          Console.ReadLine();
        }
        static Delegate MakeEventHandlerDelegate(MethodInfo methodInfo, object target)
        {
          ParameterInfo[] info = methodInfo.GetParameters();
          if (info.Length != 2)
            throw new ArgumentOutOfRangeException("methodInfo");
          if (!typeof(EventArgs).IsAssignableFrom(info[1].ParameterType))
            throw new ArgumentOutOfRangeException("methodInfo");
          if (info[0].ParameterType != typeof(object))
            throw new ArgumentOutOfRangeException("methodInfo");
          return Delegate.CreateDelegate(typeof(EventHandler<>).MakeGenericType(info[1].ParameterType), target, methodInfo);
        }
      }
      class Args : EventArgs
      {
        public string Value { get; set; }
      }
      class Publisher
      {
        public event EventHandler<Args> Event;
        public void Raise(string value)
        {
          if (Event != null)
          {
            Args a = new Args { Value = value };
            Event(this, a);
          }
        }
      }
      class Subscriber
      {
        public void Handle(object sender, Args args)
        {
          Console.WriteLine("Handle called with {0}.", args.Value);
        }
      }
