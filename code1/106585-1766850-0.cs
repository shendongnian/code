    interface IReadOnlyObject
    {
        int Property { get; }
    }
    class DALObject : IReadOnlyObject
    {
        public int Property { get; set; }
    }
