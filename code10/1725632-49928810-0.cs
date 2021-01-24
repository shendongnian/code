    public static IEnumerable<ProjectInfo> GetResponse()
    {
            IEnumerable<ProjectInfo> items = new List<ProjectInfo>();
            using (StreamReader r = new StreamReader("Data.json"))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<ProjectInfo>>(json);
            }
            return items;
    }
