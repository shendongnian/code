        public static DBConfig Carregar()
        { 
            var data = File.ReadAllText("dbconfig.json");
            var config = JsonConvert.DeserializeObject<DBConfig>(data);
            return config;
        }
