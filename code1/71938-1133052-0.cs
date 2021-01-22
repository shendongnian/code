    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class EmailConfiguration : object,  System.ComponentModel.INotifyPropertyChanged {
    
    private string dataBoxIDField;
    
    private EmailConfigurationDefaultSendToAddressCollection[] defaultSendToAddressCollectionField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string DataBoxID {
        get {
            return this.dataBoxIDField;
        }
        set {
            this.dataBoxIDField = value;
            this.RaisePropertyChanged("DataBoxID");
        }
    }
