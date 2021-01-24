    public static Models.RootModel getJson()
        {
            using (StreamReader r = new StreamReader("c:\\LOG\\20180528\\201805281039.json"))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<Models.RootModel>(json);
            }
        }
