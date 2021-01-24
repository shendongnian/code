    public SNMPTableEntity()
        {
          snmpPoperties = new Dictionary<ObjectIdentifier, PropertyInfo>();
          foreach (PropertyInfo myProperty in GetType().GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
          {
            CustomAttributeData snmpAttribure = myProperty.CustomAttributes.Where(x => x.AttributeType == typeof(SNMPPropertyAttribute)).FirstOrDefault();
            if (snmpAttribure != null)
              snmpPoperties.Add(new ObjectIdentifier((string)snmpAttribure.ConstructorArguments[0].Value), myProperty);
          }
        }
