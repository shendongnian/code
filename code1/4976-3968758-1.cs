    // <Name>Potentially unused types</Name>
    WARN IF Count > 0 IN SELECT TOP 10 TYPES WHERE 
     TypeCa == 0 AND    // Ca=0 -> No Afferent Coupling -> 
                        // The type is not used in the 
                        // context of this application.
    
     !IsPublic AND      // Public types might be used 
                        // by client applications of your
                        // assemblies.
    
     !NameIs "Program"  // Generally, types named Program 
                        // contain a Main() entry-point 
                        // method and this condition avoid 
                        // to consider such type as 
                        // unused code.
