    using System.Threading;
    EventWaitHandle done = new EventWaitHandle(false, EventResetMode.AutoReset);
    void DoStuff()
    {
        while (MyCollection.HasStuff)
        {
            // note: something smelled fishy here.
            // i assume your collection removes the first entry when you call First
            var first = MyCollection.First();
            AddNumbers(first.a, first.b, StuffDone);
            done.WaitOne();
        }
    }
    void StuffDone(int result)
    {
        done.Set();
    }
