    //Given the following class
    [XmlType("T")]
    public class Foo
    {
        internal Foo()
        {
    
        }
    
        [XmlAttribute("p")]
        public uint Bar
        {
            get;
            set;
        }
    }
    
    [WebService(Namespace = "http://me.com/10/8")]
    [System.ComponentModel.ToolboxItem(false)]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ScriptService]
    public class MyService : System.Web.Services.WebService
    {
    
        //Return Anonymous Type to omit the __type property from JSON serialization
        [WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json, XmlSerializeString = false)]
        public object GetFoo(int pageId)
        {
            //Kludge, returning an anonymois type using link, prevents returning the _type attribute.
            List<Foo> foos = new List<Foo>();
            rtnFoos.Add( new Foo(){
                Bar=99
            }};
    
            var rtn = from g in foos.AsEnumerable()
                       select g;
    
            return rtn;
        }
    }
