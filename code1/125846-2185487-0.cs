    public partial class NorthwindDataContext
    {
        public override void SubmitChanges(ConflictMode failureMode)
        {
            EntityValidator.Validate(this.GetChangedEntities());
            base.SubmitChanges(failureMode);
        }
        
        private IEnumerable<object> GetChangedEntities()
        {
            ChangeSet changes = this.GetChangeSet();
            return changes.Inserts.Concat(changes.Updates);
        }
    }
