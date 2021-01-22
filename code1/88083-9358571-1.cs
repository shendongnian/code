    Type type = WMQXMLMessageTypeFactory.CreateMessageType<TenantRequest>();
    MetaData metadata = new MetaData();
    metadata.ID = Guid.NewGuid().ToString();
    metadata.Created = DateTime.Now;
    metadata.Application = new schemasdev.local.tenant.Application();
    metadata.Application.Name = "Publish Tenant";
    metadata.Application.Core = ApplicationCore.PropertySystem;
    NewOperation newoperation = new NewOperation();
    newoperation.Tenant = new Tenant();
    newoperation.Tenant.Code = "001";
    newoperation.Tenant.Name = "Mister X";
    object request = type.GetConstructor(new Type[0]).Invoke(new object[0]);
    (request as TenantRequest).MetaData = metadata;
    (request as TenantRequest).New = newoperation;
                
    //Setting the schema location property
    type.InvokeMember("SchemaLocation", System.Reflection.BindingFlags.SetField, null, request, new object[] { "http://schemasdev.local/2012-01/Tenant/1.0/Tenant.xsd" });
    System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(type);
    stream = new System.IO.MemoryStream();
    serializer.Serialize(stream, request);
    Console.WriteLine(UTF8Encoding.UTF8.GetString(stream.ToArray()));
