    interface ICanSerialize
    {
        void Serialize(ISerializeMedium m);
    }
    interface ISerializeMedium
    {
        void Serialize(string name, ref int value);
        void Serialize(string name, ref bool value);
        void Serialize(string name, ref string value);
        void Serialize<T>(string name, ref T value) where T : ICanSerialize;
        void Serialize<T>(string name, ref ICollection<T> value) where T : ICanSerialize;
        // etc.
    }
