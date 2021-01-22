        public override void SubmitChanges(System.Data.Linq.ConflictMode failureMode)
    {
        try
        {
            base.SubmitChanges(failureMode);
        }
        catch (Exception e)
        {
            throw new ValidationException("Something is wrong", e);
        }
    }
