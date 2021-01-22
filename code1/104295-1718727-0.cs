    using (StreamReader reader = File.OpenText("data.txt")) {
        string line;
        DbConnectionStringBuilder db = new DbConnectionStringBuilder();
        while ((line = reader.ReadLine()) != null) {
            db.ConnectionString = line;
            foreach (string key in db.Keys) {
                Console.WriteLine(key);
                Console.WriteLine(db[key]);
            }
        }
    }
