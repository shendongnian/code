    using System;
    using System.IO;
    using System.Xml.Serialization;
    
    namespace ConsoleApplication1
    {
      class Program
      {
        static void Main(string[] args)
        {
          string xml =
            @"<a> 
                <b> 
                  <c>val1</c> 
                  <d>val2</d> 
                </b> 
                <b> 
                  <c>val3</c> 
                  <d>val4</d> 
                </b> 
              </a>";
    
          XmlSerializer xs = new XmlSerializer(typeof(a));
          a i = (a)xs.Deserialize(new StringReader(xml));
    
          if (i != null && i.bb != null && i.bb.Length > 0)
          {
            Console.WriteLine(i.bb[0].c); 
          }
          else
          {
            Console.WriteLine("Something went wrong!"); 
          }
    
          Console.ReadKey();
        }
      }
    
      
      [XmlRoot("a")]
      public class a
      {    
        [XmlElement("b")]
        public b[] bb { get; set; }
      }
      
      public class b
      {
        [XmlElement("c")]
        public string c { get; set; }
        [XmlElement("d")]
        public string d { get; set; }
      }  
    }
