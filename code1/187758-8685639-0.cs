    public interface ISimpleStringBuilder
    {
        ISimpleStringBuilder Append(string value);
        ISimpleStringBuilder Clear();
        int Lenght { get; }
        int Capacity { get; }
    }
