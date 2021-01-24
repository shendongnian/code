    DateTime currentDate = DateTime.Now.Date;
    for (int i = 0; i < List.Count || i < 60; i += 2) {
        AddClient(i, currentDate);
        if (i + 1 < List.Count) {
            AddClient(i + 1, currentDate);
        }
        currentDate = currentDate.AddDays(1);
    }
    void AddClient(int clientIndex, DateTime dateTime)
    {
        var client = new Client {
            Name = List[clientIndex].Name,
            Date = dateTime
        };
        List2.Add(client);
    }
