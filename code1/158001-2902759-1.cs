				public static byte[] Serialize(Object o){           
				 MemoryStream stream = new MemoryStream();
				 
				 BinaryFormatter formatter = new BinaryFormatter();
				 
				 formatter.AssemblyFormat
				 
					 = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple;
					 
				 formatter.Serialize(stream, o);
				 
				 return stream.ToArray();
				 
				}
				
				public static Object BinaryDeSerialize(byte[] bytes){
				
				  MemoryStream stream = new MemoryStream(bytes);
				  
				  BinaryFormatter formatter = new BinaryFormatter();
				  
				  formatter.AssemblyFormat 
					  = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple;
					  
				  formatter.Binder 
					  = new VersionConfigToNamespaceAssemblyObjectBinder();
					  
				  Object obj = (Object)formatter.Deserialize(stream);
				  
				  return obj;
				  
				}
				
