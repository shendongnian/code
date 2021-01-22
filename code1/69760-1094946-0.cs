    class YourClass {
       Type type;
        
       public YourClass(Type type) {
           this.type = type;
       }
       public XmlSerializer Method() {
           return new XmlSerializer(type);
       }
    }
   
    ...
    new YourClass(typeof(Foo));
