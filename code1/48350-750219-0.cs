                foreach (MemberInfo mi in t.GetMembers() )
                {                                  
    
                    // If the member is a property, display information about the property's accessor methods.
                    if (mi.MemberType==MemberTypes.Property)
                    {
                        foreach ( MethodInfo am in ((PropertyInfo) mi).GetAccessors() )
                        {
                            Display(indent+1, "Accessor method: {0}", am);
                        }
                    }
                }
