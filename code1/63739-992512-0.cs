    public interface ITag
    {
        string TagName { get; }
        Type Type { get; }
        object InMemValue { get; set; }
        object OnDiscValue { get; set; }
    }
