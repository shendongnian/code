    var msgEnumerator = queue.GetMessageEnumerator2();
    var messages = new List<System.Messaging.Message>();
    while (msgEnumerator.MoveNext(new TimeSpan(0, 0, 1)))
    {
        var msg = queue.ReceiveById(msgEnumerator.Current.Id, new TimeSpan(0, 0, 1));
        messages.Add(msg);
    }
