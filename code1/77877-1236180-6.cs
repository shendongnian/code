    var bestConnection = ElseIfOrDefault(
        c => c != null && !(c.IsBusy || c.IsFull),
        server1.GetConnection,
        server2.GetConnection,
        server3.GetConnection);
