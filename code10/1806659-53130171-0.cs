    public interface IRule
    {
        void Transform(object o);
    }
    public abstract class SingletonBase<T> where T : SingletonBase<T>, new()
    {
        public static T Instance { get; } = new T();
    }
    public class SpecificRule1 : SingletonBase<SpecificRule1>, IRule
    {
        public void Transform(object o) => throw new NotImplementedException();
    }
    public class SpecificRule2 : SingletonBase<SpecificRule2>, IRule
    {
        public void Transform(object o) => throw new NotImplementedException();
    }
    public class RuleSet : List<IRule>
    {
        public void Add<TRule>() where TRule : SingletonBase<TRule>, IRule, new()
        {
            this.Add(SingletonBase<TRule>.Instance);
        }
    }
