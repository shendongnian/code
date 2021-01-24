    var subClassB = new SubClassB();
    
    var ValidationMethod = subClassB.GetType()
                                    .BaseType?
                                    .GetMethod("Validate", BindingFlags.NonPublic | BindingFlags.Instance);
    
    ValidationMethod?.Invoke(subClassB, null);
