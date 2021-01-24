    [System.Xml.Serialization.XmlElementAttribute(Order=0)]
    public System.bool IsActive{
        get {
            return this.isActiveField;
        }
        set {
            this.isActiveField= value;
            this.RaisePropertyChanged("IsActive");
        }
    }
    
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool IsActiveSpecified{
        get {
            return this.IsActiveSpecified;
        }
        set {
            this.IsActiveSpecified= value;
            this.RaisePropertyChanged("IsActiveSpecified");
        }
    }
