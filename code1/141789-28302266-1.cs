    typeof(T).Name would work
    But depending on it and making decisions based on it is probably not a good idea.
    The important rule here is that you probably should use the FullName whenever possible. 
    For instance in switch case statements or in if else blocks or in dictionary keys.
    Class name is not the ideal thing to depend on as you can potentially 
    have same class name in different namespaces.
    NamespaceA.String and NamespaceB.String is perfectly possible...
