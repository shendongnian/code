    private static void BuildUserInfo()
    {
        // ...
        //Serialize
        File.WriteAllText("OUTFILE.JSON", Newtonsoft.Json.JsonConvert.SerializeObject(users));
    }
    private static void ReadUserInfo()
    {
        Users retrievedUsers = null;
        if (File.Exists("OUTFILE.JSON"))
        {
            var json = File.ReadAllText("OUTFILE.JSON");
            retrievedUsers = Newtonsoft.Json.JsonConvert.DeserializeObject<Users>(json);
        }
    }
