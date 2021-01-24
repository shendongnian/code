    const int ClientsPerDay = 2;
    DateTime currentDate = DateTime.Now.Date;
    for (int i = 0; i < List.Count || i < ClientsPerDay * 30; i += ClientsPerDay) {
        for (int j = 0; j < ClientsPerDay; j++) {
            int clientIndex = i + j;
            if (clientIndex < List.Count) {
                var client = new Client {
                    Name = List[clientIndex].Name,
                    Date = currentDate
                };
                List2.Add(client);
            }
        }
        currentDate = currentDate.AddDays(1);
    }
