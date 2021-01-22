    [System.Xml.Serialization.XmlElementAttribute(Order=3)]
    public string TimeProperty {
        get {
            return this.timePropertyField;
        }
        set {
            this.timePropertyField = value;
            this.RaisePropertyChanged("TimeProperty");
        }
    }
