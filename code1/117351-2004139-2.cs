    public class myClass : IDisposable
    {
        public SqlDataReader dataReader { get; set; }
        #region IDisposable Members
        public void Dispose()
        {
            dataReader.Dispose();
            //My dispose code
        }
        #endregion
    }
