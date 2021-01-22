                foreach (MemberInfo mi in t.GetMembers() )
                {                                  
    
                    // If the member is a property, display information about the
                    //    property's accessor methods.
                    if (mi.MemberType==MemberTypes.Property)
                    {
                        PropertyInfo pmi = ((PropertyInfo) mi);
                        foreach ( MethodInfo am in pmi.GetAccessors() )
                        {
                            Display(indent+1, "Accessor method: {0}", am);
                        }
                    }
                }
