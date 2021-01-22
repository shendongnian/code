    public interface IEval<T>{
        Func<T, bool> Expression { get; }
        Func<bool, bool, bool> Combinator { get; }
        string Key { get; }
    }
