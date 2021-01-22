    foreach (PropertyDescriptor info in properties) {
        for (int i = 0; i < nwReader.FieldCount; i++) {
            if (info.Name == nwReader.GetName(i)) {
                // This loop runs fine but there is no change to obj!!
                info.SetValue(obj, nwReader[i]);
                break;
            }
        }
    }
