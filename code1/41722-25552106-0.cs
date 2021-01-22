      public class Foo
      {
          private string[] contexts;
          /// <remarks/>
          [System.Xml.Serialization.XmlArrayItemAttribute("Context", 
           typeof(Property), IsNullable = false)]
          public string[] Contexts
          {
              get { return this.contexts; }
              set { this.contexts = value; }
          }
      }
