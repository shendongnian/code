    static void Main(string[] args)
    {
        PublisherClass publisher = new PublisherClass();
        SubscriberClass1 subscriber1 = new SubscriberClass1();
        SubscriberClass2 subscriber2 = new SubscriberClass2();
        publisher.UpdateName("Name1");
        Console.WriteLine(subscriber1.Name);
        Console.WriteLine(subscriber2.Name);
    }
