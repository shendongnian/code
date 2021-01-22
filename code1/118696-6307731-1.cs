    // Add a reference to System.Web.Extensions **(.NET 4.0 required)**
    using System.Web.Script.Serialization;
    ...
    // To serialize...
    JavaScriptSerializer serializer = new JavaScriptSerializer();
    String serializedData = serializer.Serialize(data);
    
    // To deserialize...
    deserializedData = serializer<data.GetType()>(serializedData);
    // OR even
    var anyObject = serializer<dynamic>(serializedData);
