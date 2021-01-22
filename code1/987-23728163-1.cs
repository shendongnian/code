    var obj = new object();
    using (var tryLock = new TryLock(obj))
    {
        if (tryLock.HasLock)
        {
            Console.WriteLine("Lock acquired..");
        }
    }
