    class C : ICanSerialize
    {
        string _firstName;
        bool _happy;
        public void Serialize(ISerializeMedium m)
        {
            m.Serialize("firstName", ref _firstName);
            m.Serialize("happy", ref _happy);
        }
    }
