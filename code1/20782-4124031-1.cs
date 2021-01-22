    [ComVisible(false)]
    public class CustomDispatch : IReflect
    {
        // Called by CLR to get DISPIDs and names for properties
        PropertyInfo[] IReflect.GetProperties(BindingFlags bindingAttr)
        {
            return this.GetType().GetProperties(bindingAttr);
        }
    
        // Called by CLR to get DISPIDs and names for fields
        FieldInfo[] IReflect.GetFields(BindingFlags bindingAttr)
        {
            return this.GetType().GetFields(bindingAttr);
        }
    
        // Called by CLR to get DISPIDs and names for methods
        MethodInfo[] IReflect.GetMethods(BindingFlags bindingAttr)
        {
            return this.GetType().GetMethods(bindingAttr);
        }
    
        // Called by CLR to invoke a member
        object IReflect.InvokeMember(string name, BindingFlags invokeAttr, Binder binder, object target, object[] args, ParameterModifier[] modifiers, System.Globalization.CultureInfo culture, string[] namedParameters)
        {
            try
            {
                // Test if it is an indexed Property
                if (name != "Item" && (invokeAttr & BindingFlags.GetProperty) == BindingFlags.GetProperty && args.Length > 0 && this.GetType().GetProperty(name) != null)
                {
                    object IndexedProperty = this.GetType().InvokeMember(name, invokeAttr, binder, target, null, modifiers, culture, namedParameters);
                    return IndexedProperty.GetType().InvokeMember("Item", invokeAttr, binder, IndexedProperty, args, modifiers, culture, namedParameters);
                }
                // default InvokeMember
                return this.GetType().InvokeMember(name, invokeAttr, binder, target, args, modifiers, culture, namedParameters);
            }
            catch (MissingMemberException ex)
            {
                // Well-known HRESULT returned by IDispatch.Invoke:
                const int DISP_E_MEMBERNOTFOUND = unchecked((int)0x80020003);
                throw new COMException(ex.Message, DISP_E_MEMBERNOTFOUND);
            }
        }
    
        FieldInfo IReflect.GetField(string name, BindingFlags bindingAttr)
        {
            return this.GetType().GetField(name, bindingAttr);
        }
    
        MemberInfo[] IReflect.GetMember(string name, BindingFlags bindingAttr)
        {
            return this.GetType().GetMember(name, bindingAttr);
        }
    
        MemberInfo[] IReflect.GetMembers(BindingFlags bindingAttr)
        {
            return this.GetType().GetMembers(bindingAttr);
        }
    
        MethodInfo IReflect.GetMethod(string name, BindingFlags bindingAttr)
        {
            return this.GetType().GetMethod(name, bindingAttr);
        }
    
        MethodInfo IReflect.GetMethod(string name, BindingFlags bindingAttr,
        Binder binder, Type[] types, ParameterModifier[] modifiers)
        {
            return this.GetType().GetMethod(name, bindingAttr, binder, types, modifiers);
        }
    
        PropertyInfo IReflect.GetProperty(string name, BindingFlags bindingAttr,
        Binder binder, Type returnType, Type[] types,
        ParameterModifier[] modifiers)
        {
            return this.GetType().GetProperty(name, bindingAttr, binder,
            returnType, types, modifiers);
        }
    
        PropertyInfo IReflect.GetProperty(string name, BindingFlags bindingAttr)
        {
            return this.GetType().GetProperty(name, bindingAttr);
        }
    
        Type IReflect.UnderlyingSystemType
        {
            get { return this.GetType().UnderlyingSystemType; }
        }
    }
