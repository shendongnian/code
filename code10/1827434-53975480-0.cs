        using (StreamReader reader = new StreamReader(argv[0]))
        {
            string temp;
            Line line = new Line();
            while ((temp = reader.ReadLine()) != null)
            {
               line.line.Add(new Station
               {
                 stationName = "value you want to assign"
               });
            }
        }
