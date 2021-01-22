    public class BaseDataContext : DataContext
    {
      // constructor is needed if you have different contexts
        public BaseDataContext(string fileOrServerOrConnection) : base(fileOrServerOrConnection)
        {
        }
        public override void SubmitChanges(ConflictMode failureMode)
        {
            try
            {
                base.SubmitChanges(failureMode);
            }
            catch (Exception ex)
            {
    // do whatever you would like with the exception
            }
        }
    }
