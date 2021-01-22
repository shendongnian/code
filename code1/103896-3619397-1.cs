    // <Name>Potentially unused fields</Name>
    WARN IF Count > 0 IN SELECT FIELDS 
    WHERE 
     FieldCa == 0 AND  // Ca=0 -> No Afferent Coupling -> The field is not used in the context of this application.
     !IsPublic AND     // Although not recommended, public fields might be used by client applications of your assemblies.
     !IsLiteral AND    // The IL code never explicitely uses literal fields.
     !IsEnumValue AND  // The IL code never explicitely uses enumeration value.
     !NameIs "value__" // Field named 'value__' are relative to enumerations and the IL code never explicitely uses them."
