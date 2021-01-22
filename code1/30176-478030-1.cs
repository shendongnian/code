    var properties = TypeDescriptor.GetProperties(sample);
    while (nwReader.Read()) {
        // No way to create a constructor so this call creates the object without calling a ctor. Could this be a source of the problem?
        T obj = (T)FormatterServices.GetUninitializedObject(typeof(T)); 
        foreach (PropertyDescriptor info in properties) {
            for (int i = 0; i < nwReader.FieldCount; i++) {
                if (info.Name == nwReader.GetName(i)) {
                    // This loop runs fine but there is no change to obj!!
                    info.SetValue(obj, nwReader[i]);
                    break;
                }
            }
        }
        fdList.Add(obj);
    }
