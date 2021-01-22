    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("svcutil", "3.0.4506.2152")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://myproduct.mycompany.com/")]
    public partial class MyError
    {
    
      // other stuff
    
      private string descriptionField;
    
      /// <remarks/>
      [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 1)]
      public string description
      {
        get
        {
    	  return this.descriptionField;
        }
        set
        {
    	  this.descriptionField = value;
        }
      }
    }
