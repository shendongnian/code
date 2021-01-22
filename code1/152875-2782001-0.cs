        Server server = new Server();
        server.Connect(cubeConnectionString);
        Database database = server.Databases.FindByName(databaseName);
        Cube cube = database.Cubes.FindByName(cubeName);
        cube.Process(ProcessType.ProcessFull);
