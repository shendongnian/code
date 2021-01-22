        generator.Emit(OpCodes.Newobj, typeof(StringBuilder).GetConstructor(Type.EmptyTypes)); //make our string builder 
        generator.Emit(OpCodes.Stloc, sb);                     //make a pointer to our new sb
        
        //iterate through all the instance of T's props and sb.Append their values.
        PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        generator.Emit(OpCodes.Ldloc, sb);                     //load the sb pointer
        foreach (var info in props)
        {   
            generator.Emit(OpCodes.Ldarg_0);
            generator.Emit(OpCodes.Callvirt, info.GetGetMethod()); //call the Getter
            if (info.PropertyType.IsValueType) {
                generator.Emit(OpCodes.Box, info.PropertyType);
            }         
            generator.Emit(OpCodes.Callvirt, AppendMethod);        //Call Append 
        }
        generator.Emit(OpCodes.Ret);           //return pointer to sb
