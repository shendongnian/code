    using System.Linq;
    
    // ...
    
    public UnityEngine.UI.ToggleGroup ToggleGroup ; // Drag & drop the desired ToggleGroup in the inspector
    
    private void Start()
    {
        if( ToggleGroup == null ) ToggleGroup = GetComponent<ToggleGroup>();
    }
    
    public void LogSelectedToggle()
    {
        // May have several selected toggles
        foreach( Toggle toggle in ToggleGroup.ActiveToggles() )
        {
             Debug.Log( toggle, toggle ) ;
        }
    
        // OR
    
        Toggle selectedToggle = ToggleGroup.ActiveToggles().FirstOrDefault();
        if( selectedToggle != null )
            Debug.Log( selectedToggle, selectedToggle ) ;
    }
