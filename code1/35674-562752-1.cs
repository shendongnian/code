    public static bool PersistChanges<T>(this T source)
      where T : BaseModel
    {
            // Context is of type "ObjectContext"
    //static property which holds a Context instance is dangerous.
            DatabaseHelper.Context.SafelyPersistChanges<T>(source);
    }
