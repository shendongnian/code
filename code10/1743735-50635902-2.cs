        static void Main(string[] args)
        {
            PublisherClass p = new PublisherClass();
            SubscriberClass s = new SubscriberClass(p);
            p.RaiseAnEvent();   
        }
