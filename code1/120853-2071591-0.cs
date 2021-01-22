    public interface IDataMember<T> : IDataMember
    {
        T Value { get; set; }
    
        T Get();
    
        void Set(T value);
    }
    
    public interface IDataMember
    {
        string FieldName { get; set; }
        string OracleName { get; set; }
        Type MemberType { get; }
        bool HasValue { get; set; }
        bool Changed { get; set; }
        bool NotNull { get; set; }
        bool PrimaryKey { get; set; }
        bool AutoIdentity { get; set; }
        EntityBase Entity { get; set;}
    
        object GetObjectValue();
    
        void SetNull();
    }
