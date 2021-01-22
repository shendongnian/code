    public void SomeMethod()
    {
        ChangeNotifier notifier = new ChangeNotifier(10);
        // Subscribe to the event and output the number when it fires.
        notifier += (s, e) => Console.Writeline(Notifier.Number.ToString());
        notifier.Number = 10; // Does nothing, this is the same value
        notifier.Number = 20; // Outputs "20" because the event fires and the lambda runs.
    }
