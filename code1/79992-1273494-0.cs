    public interface IFormatter<TData, TFormat>
    {
        TFormat Format(TData data);
    }
    public abstract class BaseFormatter<TData> : IFormatter<TData, XElement>
    {
        #region IFormatter<TData,XElement> Members
        public XElement Format(TData data)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
