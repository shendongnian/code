    public static void something()
    {
        File.ReadLines(filePath)
            .AsParallel()
            .Select(JsonConvert.DeserializeObject<List<LiveAMData>>)
            .ForAll(WriteRecord);
    }
