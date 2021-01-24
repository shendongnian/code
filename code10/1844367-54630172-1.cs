    List<Task<string>> tasks = new List<Task<string>>();
    foreach(string thisserver in server) {
        foreach (string thispassword in password) {
            foreach (string thisusername in username) {
                Console.WriteLine(thisserver);
                Task<string> task = SpawnClient(f, thisusername, thispassword, thisserver);
                tasks.Add(task);
            }
        }
    }
    var allResults = await Task.WhenAll(tasks);
