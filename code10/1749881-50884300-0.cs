    using (var messageEnumerator = message.GetEnumerator())
    {
        while (messages.MoveNext())
        {
            var message = messages.Current;
            Console.WriteLine(message);
        }
    }
