    class MySerializationBinder : SerializationBinder
    {
    
        public override Type BindToType(string assemblyName, string typeName) 
        {
              Type typeToDeserialize = null;    
              
              // To return the type, do this:
              if(typeName == "TypeToConvertFrom")
              {
                   typeToDeserialize = typeof(TypeToConvertTo);
              }
        
              return typeToDeserialize;
        }
    }
