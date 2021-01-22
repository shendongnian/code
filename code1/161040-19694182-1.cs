    [Serializable()]     
    public class foo
    { 
      public foo(){}
      [XmlElement("propOne")]
      [EditorBrowsable(EditorBrowsableState.Never)]
      public string propOneString {get;set;}
      [XmlIgnore]
      private int? propOneInternal = null;
      [XmlIgnore]
      private bool propOneSet = false;
      [XmlIgnore]
      public int? propOne
      {
        get
        {
          if (!propOneSet)
          {
            if(!string.IsNullOrEmpty(propOneString)
            {
              propOneInternal = int.Parse(propOneString);
            }
            //else leave as pre-set default: null
            propOneSet = true;
          }
          return propOneInternal;
        }
        set { propOneInternal = value; }
      }
    }
