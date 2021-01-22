    interface IMeasurementInterface
    {
        void Initialize();
        void Close();
        void Setup();
        void Read (FileReader as <whatever read file object you are using>)
        void Store (FileReader as <whatever read file object you are using>)
        string Name();
    }
