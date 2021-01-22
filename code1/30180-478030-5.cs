    PropertyInfo[] properties = sample.GetType().GetProperties();
    while (nwReader.Read()) {
        // No way to create a constructor so this call creates the object without calling a ctor. Could this be a source of the problem?
        T obj = (T)FormatterServices.GetUninitializedObject(typeof(T));
        foreach (PropertyInfo info in properties) {
            for (int i = 0; i < nwReader.FieldCount; i++) {
                if (info.Name == nwReader.GetName(i)) {
                    // This loop will throw an exception as PropertyInfo.GetSetMethod fails
                    info.SetValue(obj, nwReader[i], null);
                    break;
                }
            }
        }
        fdList.Add(obj);
    }
 
