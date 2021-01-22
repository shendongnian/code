    // change your code to this
    public abstract class BaseModel<TDerived> where TDerived : BaseModel
    {
        public bool PersistChanges() {
            // Context is of type "ObjectContext"
            DatabaseHelper.Context.SafelyPersistChanges((TDerived)this);
            //                                            ^
            // note the cast here: -----------------------|
        }
    }
    public class Lead : BaseModel<Lead> { }
    
    // the rest of your code is unchanged
