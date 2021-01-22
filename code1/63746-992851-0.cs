    public interface ITag
    {
        void CopyFrom(bool sourceIsMem, ITag sourceTag, bool targetIsMem);
    }
    public class Tag<T> : ITag<T>
    {
        public void CopyFrom(bool sourceIsMem, ITag sourceTag, bool targetIsMem)
        {
            ITag<T> castSource = sourceTag as ITag<T>;
            if (castSource == null)
                throw new ArgumentException(
                    "Source tag is of an incompatible type", "sourceTag");
            if (targetIsMem)
                InMemValue = sourceIsMem ?
                    castSource.InMemValue : castSource.OnDiscValue;
            else
                OnDiscValue = sourceIsMem ?
                    castSource.InMemValue : castSource.OnDiscValue;
        }
    }
