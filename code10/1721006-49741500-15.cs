    const int ClientsPerDay = 2, NumDays = 30;
    DateTime date = DateTime.Now.Date;
    for (int i = 0; i < ClientsPerDay * NumDays; i += ClientsPerDay) {
        for (int j = 0; j < ClientsPerDay; j++) {
            int clientIndex = (i + j) % List.Count; // clientIndex = [0 .. List.Count - 1]
            var client = new Client {
                Name = List[clientIndex].Name,
                Date = date
            };
            List2.Add(client);
        }
        date = date.AddDays(1);
    }
