    public interface IExtractor
    {
        string RecordType { get; }
        string ErrorMessage { get; }
        string GetValue(object record);
    }
