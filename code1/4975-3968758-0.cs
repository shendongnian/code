    // <Name>Potentially unused methods</Name>
    WARN IF Count > 0 IN SELECT TOP 10 METHODS WHERE 
     MethodCa == 0 AND        // Ca=0 -> No Afferent Coupling -> 
                              // The method is not used in the 
                              // context of this application.
    
     !IsPublic AND            // Public methods might be used by 
                              // client applications of your assemblies.
    
     !IsEntryPoint AND        // Main() method is not used by-design.
    
     !IsExplicitInterfaceImpl // The IL code never explicitely 
     AND                      // calls explicit interface methods 
                              // implementation.
    
     !IsClassConstructor AND  // The IL code never explicitely 
                              // calls class constructors.
    
     !IsFinalizer             // The IL code never explicitely 
                              // calls finalizers.
