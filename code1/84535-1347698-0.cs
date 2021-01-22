User theUser = new User();
theUser.Name = "Joe";
System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(myPerson.GetType());
MemoryStream ms = new MemoryStream();
serializer.WriteObject(ms, theUser );
string json = Encoding.Default.GetString(ms.ToArray()); 
 
