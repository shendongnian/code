    public static void ProcessSingle(MyInputData inputData)
    {
        var dbData = GetDataFromDb(); // get data from DB async using Dapper
        // some lasting processing (sync)
        SaveDataToDb(); // async save processed data to DB using Dapper
    }
