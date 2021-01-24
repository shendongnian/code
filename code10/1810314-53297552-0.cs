    public static class Config
    {
        public static YourCustomType Data { get; private set; }
        
        public static void LoadXml()
        {
            Data = YourDeserializationLogic();
        }
        public static void SaveXml()
        {
            YourSerializationLogic(Data);
        }
    }
