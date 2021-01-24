    [CreateAssetMenuAttribute(menuName = "Decision")]
    public Decision : ScriptableObject
    {
       public string Name;
       public DecisionState State; // Use an Enum with states "Inactive" "Completed", "Failed", "Unavailable" etc.
       // Other variables that may be relevant, like score or whatever   
    }
    
