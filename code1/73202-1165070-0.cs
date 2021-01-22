    public class ContextProvider : IProvider
    {
        #region IProvider Members
        public object Create(IContext context)
        {
            return new MyDataContext();
        }
        public Type Type
        {
            get { throw new NotImplementedException(); }
        }
        #endregion
    }
