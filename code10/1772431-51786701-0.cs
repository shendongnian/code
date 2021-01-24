            var connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("DB Name");
            var collection = database.GetCollection<Class Name>("Table Name");
            List<Class Name> list = await collection .Find(x => true).ToListAsync();
            dataGridView1.DataSource = list
