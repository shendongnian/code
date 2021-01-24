    public enum MethodNames {
       BARCODE128,
       BARCODE128HR, etc
    }
    
    /// later
    LabelFields obj = new LabelFields();
    string lv = "";
    switch (MethodName) {
      case MethodNames.BARCODE128:
           lv = obj.BARCODE128HR(mParam);
           break;
      ///and the rest
    }
