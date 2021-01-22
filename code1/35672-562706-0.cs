    public class Lead { 
        public override bool PersistChanges() {
            // Context is of type "ObjectContext"
            DatabaseHelper.Context.SafelyPersistChanges(this);
        }
    }
