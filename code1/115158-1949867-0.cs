    public interface IEval<T>{
        Func<T, bool> Expression { get; }
        Func<bool, bool> Combine { get; }
        string Key { get; }
    }
