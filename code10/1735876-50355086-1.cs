     byte[] bytes = MessagePackSerializer.Typeless.Serialize(instance);
    
                    await fileManager.WriteAsync(bytes);
                     
                    ExtendedItem deserializedInstance = null;
    
                    deserializedInstance = MessagePackSerializer.Typeless.Deserialize(bytes) as ExtendedItem;
                    
               
