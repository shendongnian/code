    public class MyType1 
    {
        public string Label
        {
            set {  _Label= value; } 
            get { return _Label; } 
        }
        private int _Epoch;
        public int Epoch
        {
            set {  _Epoch= value; } 
            get { return _Epoch; } 
        }        
    }
    
        String RawXml_WithNamespaces = @"
          <MyType1 xmlns='urn:booboo-dee-doo'>
            <Label>This document has namespaces on its elements</Label>
            <Epoch xmlns='urn:aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa'>0</Epoch>
          </MyType1>";
        System.IO.StringReader sr;
        sr= new System.IO.StringReader(RawXml_WithNamespaces);
        var o1= (MyType1) s1.Deserialize(new NamespaceIgnorantXmlTextReader(sr));
        System.Console.WriteLine("\n\nDe-serialized, then serialized again:\n");
        s1.Serialize(new XTWFND(System.Console.Out), o1, ns);
        Console.WriteLine("\n\n");
