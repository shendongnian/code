    IDataErrorInfo dei = obj as IDataErrorInfo;
    if(dei != null) { // supports validation
       string err = dei["PropName"]; // or .Error for overall status
       bool clean = string.IsNullOrEmpty(err);
    }
