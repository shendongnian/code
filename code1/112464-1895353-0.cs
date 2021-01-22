    [Flag]
    public enum flagCollection {
      Type1,
      Type2,
      Type4,
      Type8,
    }
    
    flagCollection testValue = flagCollection.Type2
    
    if ((testValue & flagCollection.Type2) == flagCollection.Type2) {
       MessageBox.Show("y");
    } else {
       MessageBox.Show("n");
    }
