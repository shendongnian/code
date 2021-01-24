    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
      sealed class SNMPPropertyAttribute : Attribute
      {
        public SNMPPropertyAttribute(string propertyOID) => PropertyOID = new ObjectIdentifier(propertyOID);
    
        public ObjectIdentifier PropertyOID { get; }
      }
