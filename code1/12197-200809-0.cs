    partial class DataClasses1DataContext
    {
        public override void SubmitChanges(System.Data.Linq.ConflictMode failureMode)
        {
            if (GetChangeSet().Inserts.Count > 0)
            {
                throw new InvalidOperationException("No inserts!");
            }
            base.SubmitChanges(failureMode);
        }
    }
