      var allProps = type.GetProperties();
      var props = new MyProp[allProps.Length];
    
      for(int i =0;i<allProps.Length;i++)
      {
            var prop = allProps[i];
            // Getter dynamic method the signature would be :
            // object Get(object thisReference)
            // { return ((TestClass)thisReference).Prop; }
    
            DynamicMethod dmGet = new DynamicMethod("Get", typeof(object), new Type[] { typeof(object), });
            ILGenerator ilGet = dmGet.GetILGenerator();
            // Load first argument to the stack
            ilGet.Emit(OpCodes.Ldarg_0);
            // Cast the object on the stack to the apropriate type
            ilGet.Emit(OpCodes.Castclass, type);
            // Call the getter method passing the object on the stack as the this reference
            ilGet.Emit(OpCodes.Callvirt, prop.GetGetMethod());
            // If the property type is a value type (int/DateTime/..) box the value so we can return it
            if (prop.PropertyType.IsValueType)
            {
                  ilGet.Emit(OpCodes.Box, prop.PropertyType);
            }
            // Return from the method
            ilGet.Emit(OpCodes.Ret);
    
    
            // Setter dynamic method the signature would be :
            // object Set(object thisReference, object propValue)
            // { return ((TestClass)thisReference).Prop = (PropType)propValue; }
    
            DynamicMethod dmSet = new DynamicMethod("Set", typeof(void), new Type[] { typeof(object), typeof(object) });
            ILGenerator ilSet = dmSet.GetILGenerator();
            // Load first argument to the stack and cast it
            ilSet.Emit(OpCodes.Ldarg_0);
            ilSet.Emit(OpCodes.Castclass, type);
    
            // Load secons argument to the stack and cast it or unbox it
            ilSet.Emit(OpCodes.Ldarg_1);
            if (prop.PropertyType.IsValueType)
            {
                  ilSet.Emit(OpCodes.Unbox_Any,prop.PropertyType);
            }
            else
            {
                  ilSet.Emit(OpCodes.Castclass, prop.PropertyType);
            }
            // Call Setter method and return 
            ilSet.Emit(OpCodes.Callvirt, prop.GetSetMethod());
            ilSet.Emit(OpCodes.Ret);
    
            // Create the delegates for invoking the dynamic methods and add the to an array for later use
            props[i] =  new MyProp()
            {
                  PropName = prop.Name,
                  Setter = (Action<object, object>)dmSet.CreateDelegate(typeof(Action<object, object>)),
                  Getter = (Func<object, object>)dmGet.CreateDelegate(typeof(Func<object, object>)),
            };
     
      }
      return props;
