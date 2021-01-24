    public T Deserialize()
        {
            var jsonData = "Your string JSON data";
            var objectJSON = JsonConvert.DeserializeObject<T>(jsonData);
            return objectJSON;
        }
        public T Serialize()
        {
            var objectData = new Student();
            var objectData = JsonConvert.SerializeObject(objectData);
            return objectData;
        }
