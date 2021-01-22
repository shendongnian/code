    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    
    [XmlRootAttribute("Vendor")]
    class Vendor{
        [XmlAttribute]
        Product prod;
    }
    [XmlRootAttribute("Product")]
    class Product{
        [XmlAttribute]
        public string name="";
    }
    
    class Test{
        Vendor v=new Vendor();
        Product p=new Product();
        p.name="a cake";
        v.prod=p;
        
        //add EVERY SINGLE TYPE you use in the serialized class.
        Type[] type_list = { typeof(Product) };
        
            XmlSerializer packer = new XmlSerializer(v.GetType(),type_list);
            XmlWriter flusher = XmlWriter.Create(@"c:\bak.xml");
            
            packer.Serialize(flusher, v);
            
            flusher.Close();
            XmlReader restorer = XmlReader.Create(@"c:\bak.xml");
            Vendor v2 = (Vendor)packer.Deserialize(restorer);
        
        //v2.prod.name is now "cake"
        //COOL was my first impression :P
        
    }
    
