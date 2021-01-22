      /// <summary>
      /// Transforms each value in a dictionary to a new object with the given cast delegate
      /// </summary>
      public static Dictionary<string, To> CastValues<From, To>(this Dictionary<string, From> fromDic, Func<From, To> cast)
      {
       MetaData data;
       if (!store.TryGetValue(typeof(From), out data))
       {
        data = new MetaData();
        store.Add(typeof(From), data);
       }
    
    
       if (data.CastDictionaryValues == null)
       {
        // Create ILGenerator
        DynamicMethod dymMethod = new DynamicMethod("DoDictionaryCastValues", typeof(Dictionary<string, To>), new Type[] { typeof(Dictionary<string, From>) }, true);
        ConstructorInfo newDictionaryTo = typeof(Dictionary<string, To>).GetConstructor(new Type[] { typeof(int) });
        FieldInfo fldEntries = typeof(Dictionary<string, From>).GetField("entries", BindingFlags.NonPublic | BindingFlags.Instance);
    
        FieldInfo fldEntryKey = fldEntries.FieldType.GetElementType().GetField("key", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
        FieldInfo fldEntryValue = fldEntries.FieldType.GetElementType().GetField("value", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
    
        ILGenerator generator = dymMethod.GetILGenerator();
    
        // define labels for loop
        Label loopConditionCheck = generator.DefineLabel();
        Label insideLoop = generator.DefineLabel();
    
        // define local variables
        generator.DeclareLocal(typeof(Dictionary<string, To>)); // toDic , 0
        generator.DeclareLocal(fldEntries.FieldType.GetElementType()); // pair entry<string, from>, 1
        generator.DeclareLocal(typeof(int)); // i, 2
        generator.DeclareLocal(typeof(int)); // count, 3;
        generator.DeclareLocal(typeof(Dictionary<string, To>).GetField("entries", BindingFlags.NonPublic | BindingFlags.Instance).FieldType.GetElementType()); // entry<to> 4;
    
        // store count
        generator.Emit(OpCodes.Ldarg_0);
        generator.Emit(OpCodes.Callvirt, typeof(Dictionary<string, From>).GetProperty("Count").GetGetMethod());
        generator.Emit(OpCodes.Stloc_S, 3);
    
        generator.Emit(OpCodes.Ldloc_S, 3); // load count and pass it as capacity parameter for toDic
        generator.Emit(OpCodes.Newobj, newDictionaryTo); // toDic = new ...
        generator.Emit(OpCodes.Stloc_0);
    
        // COPY Dictionary fields to toDic
    
        // toDic.buckets = fromDic.buckets;
        generator.Emit(OpCodes.Ldloc_0);
        generator.Emit(OpCodes.Ldarg_0);
        generator.Emit(OpCodes.Ldfld, typeof(Dictionary<string, From>).GetField("buckets", BindingFlags.NonPublic | BindingFlags.Instance));
        generator.Emit(OpCodes.Stfld, typeof(Dictionary<string, To>).GetField("buckets", BindingFlags.NonPublic | BindingFlags.Instance));
    
        // toDic.comparer = fromDic.comparer;
        generator.Emit(OpCodes.Ldloc_0);
        generator.Emit(OpCodes.Ldarg_0);
        generator.Emit(OpCodes.Ldfld, typeof(Dictionary<string, From>).GetField("comparer", BindingFlags.NonPublic | BindingFlags.Instance));
        generator.Emit(OpCodes.Stfld, typeof(Dictionary<string, To>).GetField("comparer", BindingFlags.NonPublic | BindingFlags.Instance));
    
        // toDic.count = fromDic.count;
        generator.Emit(OpCodes.Ldloc_0);
        generator.Emit(OpCodes.Ldarg_0);
        generator.Emit(OpCodes.Ldfld, typeof(Dictionary<string, From>).GetField("count", BindingFlags.NonPublic | BindingFlags.Instance));
        generator.Emit(OpCodes.Stfld, typeof(Dictionary<string, To>).GetField("count", BindingFlags.NonPublic | BindingFlags.Instance));
    
        // toDic.freeCount = fromDic.freeCount;
        generator.Emit(OpCodes.Ldloc_0);
        generator.Emit(OpCodes.Ldarg_0);
        generator.Emit(OpCodes.Ldfld, typeof(Dictionary<string, From>).GetField("freeCount", BindingFlags.NonPublic | BindingFlags.Instance));
        generator.Emit(OpCodes.Stfld, typeof(Dictionary<string, To>).GetField("freeCount", BindingFlags.NonPublic | BindingFlags.Instance));
    
        // toDic.freeList = fromDic.freeList;
        generator.Emit(OpCodes.Ldloc_0);
        generator.Emit(OpCodes.Ldarg_0);
        generator.Emit(OpCodes.Ldfld, typeof(Dictionary<string, From>).GetField("freeList", BindingFlags.NonPublic | BindingFlags.Instance));
        generator.Emit(OpCodes.Stfld, typeof(Dictionary<string, To>).GetField("freeList", BindingFlags.NonPublic | BindingFlags.Instance));
    
        // toDic.entries = new Entry<,>[fromDic.entries.Length];
        generator.Emit(OpCodes.Ldloc_0);
        generator.Emit(OpCodes.Ldarg_0);
        generator.Emit(OpCodes.Ldfld, fldEntries);
        generator.Emit(OpCodes.Ldlen);
        generator.Emit(OpCodes.Newarr, typeof(Dictionary<string, To>).GetField("entries", BindingFlags.NonPublic | BindingFlags.Instance).FieldType.GetElementType());
        generator.Emit(OpCodes.Stfld, typeof(Dictionary<string, To>).GetField("entries", BindingFlags.NonPublic | BindingFlags.Instance));
    
        // End COPY
    
        // i = 0;
        generator.Emit(OpCodes.Ldc_I4_0);
        generator.Emit(OpCodes.Stloc_2);
    
        generator.Emit(OpCodes.Br, loopConditionCheck); // perform loop test
        generator.MarkLabel(insideLoop);
        {
         // pair = fromDic.entries[i];
         generator.Emit(OpCodes.Ldarg_0); // load fromDic on stack
         generator.Emit(OpCodes.Ldfld, fldEntries); // load entries field from dic on stack
         generator.Emit(OpCodes.Ldloc_2); // load i
         generator.Emit(OpCodes.Ldelem, fldEntries.FieldType.GetElementType()); // load fromDic.entries[i]
         generator.Emit(OpCodes.Stloc_1);
    
         // bypass add & insert manually into entries from toDic
    
         // entryTo = new Entry<,>();
         generator.Emit(OpCodes.Ldloca_S, 4);
         generator.Emit(OpCodes.Initobj, typeof(Dictionary<string, To>).GetField("entries", BindingFlags.NonPublic | BindingFlags.Instance).FieldType.GetElementType());
    
         // entryTo.key = entryFrom.key
         generator.Emit(OpCodes.Ldloca_S, 4);
         generator.Emit(OpCodes.Ldloc_1);
         generator.Emit(OpCodes.Ldfld, fldEntries.FieldType.GetElementType().GetField("key", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public));
         generator.Emit(OpCodes.Stfld, typeof(Dictionary<string, To>).GetField("entries", BindingFlags.NonPublic | BindingFlags.Instance).FieldType.GetElementType().GetField("key", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public));
    
         // entryTo.hashCode = entryFrom.hashCode
         generator.Emit(OpCodes.Ldloca_S, 4);
         generator.Emit(OpCodes.Ldloc_1);
         generator.Emit(OpCodes.Ldfld, fldEntries.FieldType.GetElementType().GetField("hashCode", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public));
         generator.Emit(OpCodes.Stfld, typeof(Dictionary<string, To>).GetField("entries", BindingFlags.NonPublic | BindingFlags.Instance).FieldType.GetElementType().GetField("hashCode", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public));
    
         // entryTo.next = entryFrom.next
         generator.Emit(OpCodes.Ldloca_S, 4);
         generator.Emit(OpCodes.Ldloc_1);
         generator.Emit(OpCodes.Ldfld, fldEntries.FieldType.GetElementType().GetField("next", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public));
         generator.Emit(OpCodes.Stfld, typeof(Dictionary<string, To>).GetField("entries", BindingFlags.NonPublic | BindingFlags.Instance).FieldType.GetElementType().GetField("next", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public));
    
         // entryTo.value = 'to'
         generator.Emit(OpCodes.Ldloca_S, 4);
         // call cast(pair.value)
         generator.Emit(OpCodes.Ldloc_1);
         generator.Emit(OpCodes.Ldfld, fldEntryValue); // load value from pair on stack
         generator.Emit(OpCodes.Call, cast.Method);
         // and store the to value into the new entry
         generator.Emit(OpCodes.Stfld, typeof(Dictionary<string, To>).GetField("entries", BindingFlags.NonPublic | BindingFlags.Instance).FieldType.GetElementType().GetField("value", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public));
    
         // toDic.entries[i] = entryTo;
         generator.Emit(OpCodes.Ldloc_0); // load entries[]
         generator.Emit(OpCodes.Ldfld, typeof(Dictionary<string, To>).GetField("entries", BindingFlags.NonPublic | BindingFlags.Instance));
         generator.Emit(OpCodes.Ldloc_2); // load i
         generator.Emit(OpCodes.Ldloc_S, 4);
         generator.Emit(OpCodes.Stelem, typeof(Dictionary<string, To>).GetField("entries", BindingFlags.NonPublic | BindingFlags.Instance).FieldType.GetElementType()); // save element
    
         generator.Emit(OpCodes.Ldc_I4_1); // load 1
         generator.Emit(OpCodes.Ldloc_2); // load i
         generator.Emit(OpCodes.Add); // i + 1
         generator.Emit(OpCodes.Stloc_2); // i = i+1
        }
        generator.MarkLabel(loopConditionCheck);
    
        generator.Emit(OpCodes.Ldloc_2); // load i
        generator.Emit(OpCodes.Ldloc_S, 3); // load count
        generator.Emit(OpCodes.Blt, insideLoop); // i < fromDic.entries.Length
    
        generator.Emit(OpCodes.Ldloc_0); // return toDic;
        generator.Emit(OpCodes.Ret);
    
        data.CastDictionaryValues = dymMethod.CreateDelegate(typeof(Func<Dictionary<string, From>, Dictionary<string, To>>));
       }
       return ((Func<Dictionary<string, From>, Dictionary<string, To>>)data.CastDictionaryValues)(fromDic);
      }
