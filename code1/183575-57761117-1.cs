    static void LoadCSV()
    {
        using (var p = new ChoCSVReader<PlantType>("*** YOUR CSV FILE PATH ***")
            .WithFirstLineHeader(true)
            )
        {
            foreach (var rec in p)
            {
                Console.WriteLine(rec.Dump());
            }
        }
    }
