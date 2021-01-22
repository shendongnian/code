    public abstract class ComparableBase<T,K>
    {
        public T Value { get; protected set; }
        public K ConditionOperator { get; protected set; }
        // public abstract bool IsMatch(T other); // Is this required?
        protected ComparableBase(T value, K op)
        {
            this.Value = value;
            this.ConditionOperator = op;
        }
    }
    public enum ComparableOperator { None, Equal, Less, Greater }
    public enum LikeOrEqualOperator { None, Like, Equal }
    
    public class ComparableCondition<T> : ComparableBase<T,ComparableOperator>
    {
        public ComparableCondition(T value, ComparableOperator op):base(value, op)
        {
        }
    }
    public class LikeOrEqualCondition<T> : ComparableBase<T, LikeOrEqualOperator>
    {
        public LikeOrEqualCondition(T value, LikeOrEqualOperator op):base(value, op)
        {
        }
    }
