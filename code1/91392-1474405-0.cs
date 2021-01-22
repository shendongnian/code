    using System.Collections.Generic;
    using System.Web.Script.Serialization;
    
    namespace GoogleTranslator.GoogleJSON
    {
        public class FooTest
        {
            public void Test()
            {
                const string json = @"{
                  ""DisplayFieldName"" : ""ObjectName"", 
                  ""FieldAliases"" : {
                    ""ObjectName"" : ""ObjectName"", 
                    ""ObjectType"" : ""ObjectType""
                  }, 
                  ""PositionType"" : ""Point"", 
                  ""Reference"" : {
                    ""Id"" : 1111
                  }, 
                  ""Objects"" : [
                    {
                      ""Attributes"" : {
                        ""ObjectName"" : ""test name"", 
                        ""ObjectType"" : ""test type""
                      }, 
                      ""Position"" : 
                      {
                        ""X"" : 5, 
                        ""Y"" : 7
                      }
                    }
                  ]
                }";
    
                var ser = new JavaScriptSerializer();
                ser.Deserialize<Foo>(json);
            }
        }
    
        public class Foo
        {
            public Foo() { Objects = new List<SubObject>(); }
            public string DisplayFieldName { get; set; }
            public NameTypePair FieldAliases { get; set; }
            public PositionType PositionType { get; set; }
            public Ref Reference { get; set; }
            public List<SubObject> Objects { get; set; }
        }
    
        public class NameTypePair
        {
            public string ObjectName { get; set; }
            public string ObjectType { get; set; }
        }
    
        public enum PositionType { None, Point }
        public class Ref
        {
            public int Id { get; set; }
        }
    
        public class SubObject
        {
            public NameTypePair Attributes { get; set; }
            public Position Position { get; set; }
        }
    
        public class Position
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
    }
