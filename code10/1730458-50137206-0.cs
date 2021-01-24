    public class MyResultClass
    {
        public readonly object Value;
        public readonly Exception ResultException;
        //add more properties if needed
        public MyResultClass(object value)
        {
            this.ResultException = null;
            this.Value = value;
        }
        public MyResultClass(Exception ex)
        {
            this.ResultException = ex;
        }
    }
