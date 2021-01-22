    [ConfigurationProperty("labelsVisible", DefaultValue = true, IsRequired = false)]
    public bool LabelsVisible {
        get {
            bool? b= (bool?)this["labelsVisible"];
            return b.HasValue ? b.Value : true;
        }
    }
