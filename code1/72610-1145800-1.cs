     public static IDelivery DeserializeFromString(string xml)
    {
    //replace this stream with whatever you are useing
    StringReader strReader = new StringReader(xml);
    XmlReader reader = new XmlTextReader(fs); //important to use XmlReader
                  reader.MoveToContent(); //move to root
    
                  String className = reader.Name.Trim(); //read the class name 
    
                  //use the namespace IDelivery is located in
                  className  = "IDeliveryNamespace." + className;
    
                  //get the type
                  Type classType = Type.GetType(className);
                  XmlSerializer serializer = new XmlSerializer(Type.GetType(className));      
                  // Declare an object variable of the type to be deserialized.
                  IDelivery i;
     
                  // Use the Deserialize method to restore the object's state.
                 i = (IDelivery)Convert.ChangeType(serializer.Deserialize(reader),classType);
    
                return i;
    }
