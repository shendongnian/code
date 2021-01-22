    partial class LawEnforcementDataContext
    {
        public override void SubmitChanges(
            System.Data.Linq.ConflictMode failureMode)
        {
            ChangeSet delta = GetChangeSet();
            foreach (var reservation in delta.Deletes.OfType<Reservation>())
            {
                // etc
            }
            base.SubmitChanges(failureMode);
        }
    }
