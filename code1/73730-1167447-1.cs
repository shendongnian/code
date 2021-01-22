    List<string> requests;
    lock (Foo.Requests)
    {
        requests = new List<string>(Foo.Requests);
    }
    
    foreach (string data in requests)
    {
        // Process the data.
    
        lock (Foo.Requests)
        {
            Foo.Requests.Remove(data);
        }
    }
