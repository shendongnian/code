    // <Name>Potentially unused methods</Name>
    WARN IF Count > 0 IN SELECT METHODS WHERE
      MethodCa == 0 AND            // Ca=0 -> No Afferent Coupling -> The method is not used in the context of this application.
      !IsPublic AND                // Public methods might be used by client applications of your assemblies.
      !IsEntryPoint AND            // Main() method is not used by-design.
      !IsExplicitInterfaceImpl AND // The IL code never explicitely calls explicit interface methods implementation.
      !IsClassConstructor AND      // The IL code never explicitely calls class constructors.
      !IsFinalizer AND             // The IL code never explicitely calls finalizers.
      !IsVirtual AND
      !IsEventAdder AND
      !IsEventRemover 
----------
    // <Name>Potentially unused types</Name>
    WARN IF Count > 0 IN SELECT TYPES WHERE  
     TypeCa == 0 AND // Ca=0 -> No Afferent Coupling -> The type
                     // is not used in the context of this application.
     !IsPublic  AND  // Public types might be used by client applications of
                     // your assemblies.   
     !NameIs "Program" 
