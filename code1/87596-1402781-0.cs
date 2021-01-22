    public class Bob : IBob
    {
        #region IBob Members
        public void Foo()
        {
            this.Bar();
        }
        public int  Id
        {
	        get { throw new NotImplementedException(); }
        }
        #endregion
    }
