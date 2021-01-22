    // license: http://www.apache.org/licenses/LICENSE-2.0.html
    .assembly MyThing{}
    .class public abstract sealed MyThing.Thing
           extends [mscorlib]System.Object
    {
      .method public static !!T  GetEnumFromString<valuetype .ctor ([mscorlib]System.Enum) T>(string strValue,
                                                                                              !!T defaultValue) cil managed
      {
        .maxstack  2
        .locals init ([0] !!T temp,
                      [1] !!T return_value,
                      [2] class [mscorlib]System.Collections.IEnumerator enumerator,
                      [3] class [mscorlib]System.IDisposable disposer)
        // if(string.IsNullOrEmpty(strValue)) return defaultValue;
        ldarg strValue
        call bool [mscorlib]System.String::IsNullOrEmpty(string)
        brfalse.s HASVALUE
        br RETURNDEF         // return default it empty
        
        // foreach (T item in Enum.GetValues(typeof(T)))
      HASVALUE:
        // Enum.GetValues.GetEnumerator()
        ldtoken !!T
        call class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
        call class [mscorlib]System.Array [mscorlib]System.Enum::GetValues(class [mscorlib]System.Type)
        callvirt instance class [mscorlib]System.Collections.IEnumerator [mscorlib]System.Array::GetEnumerator() 
        stloc enumerator
        .try
        {
          CONDITION:
            ldloc enumerator
            callvirt instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
            brfalse.s LEAVE
            
          STATEMENTS:
            // T item = (T)Enumerator.Current
            ldloc enumerator
            callvirt instance object [mscorlib]System.Collections.IEnumerator::get_Current()
            unbox.any !!T
            stloc temp
            ldloca.s temp
            constrained. !!T
            
            // if (item.ToString().ToLower().Equals(value.Trim().ToLower())) return item;
            callvirt instance string [mscorlib]System.Object::ToString()
            callvirt instance string [mscorlib]System.String::ToLower()
            ldarg strValue
            callvirt instance string [mscorlib]System.String::Trim()
            callvirt instance string [mscorlib]System.String::ToLower()
            callvirt instance bool [mscorlib]System.String::Equals(string)
            brfalse.s CONDITION
            ldloc temp
            stloc return_value
            leave.s RETURNVAL
            
          LEAVE:
            leave.s RETURNDEF
        }
        finally
        {
            // ArrayList's Enumerator may or may not inherit from IDisposable
            ldloc enumerator
            isinst [mscorlib]System.IDisposable
            stloc.s disposer
            ldloc.s disposer
            ldnull
            ceq
            brtrue.s LEAVEFINALLY
            ldloc.s disposer
            callvirt instance void [mscorlib]System.IDisposable::Dispose()
          LEAVEFINALLY:
            endfinally
        }
      
      RETURNDEF:
        ldarg defaultValue
        stloc return_value
      
      RETURNVAL:
        ldloc return_value
        ret
      }
    } 
