    [ConfigurationProperty("labelsVisible", DefaultValue = true, IsRequired = false)]
    public bool LabelsVisible {
        get {
            bool? b= (bool?)this["labelsVisible"];
            if(b.HasValue) {
                return b.Value;
            }
            else {
                return true;
            }
    }
