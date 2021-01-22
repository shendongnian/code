    private static readonly Dictionary<Type,Action<Evaluation>> s_SaveFunctions =
        new Dictionary<Type,Action<Evaluation>>();
    s_SaveFunctions[typeof(ChildA)] = SaveChildA;
    s_SaveFunctions[typeof(ChildB)] = SaveChildB;
    // .. and so on.
    public SaveEvaluation( Evaluation eval )
    {
       // .. common save code ...
       // cal the appropriately typed save logic...
       s_SaveFunctions[eval.GetType()]( eval );
    }
    private static void SaveChildA( Evaluation eval ) { ... }
    private static void SaveChildB( Evaluation eval ) { ... }
