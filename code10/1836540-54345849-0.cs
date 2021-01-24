                JsonSerializer jsonMessageDeserializer = JsonMessageSerializer.Deserializer;
                
                Type type = typeof(T);
                if (type.IsInterface && TypeMetadataCache.IsValidMessageType(type))
                    type = TypeMetadataCache.GetImplementationType(type);
                using (Stream body = new MemoryStream(Encoding.UTF8.GetBytes(message)))
                    using (StreamReader streamReader = new StreamReader(body, Encoding.UTF8, false, 1024, true))
                        using (JsonTextReader jsonTextReader = new JsonTextReader((TextReader)streamReader)) 
                        {
                            Object objBody = jsonMessageDeserializer.Deserialize((JsonReader)jsonTextReader);
                            JsonReader r = ((JsonReader)new JTokenReader(GetMessageToken((objBody))));
                            object obj2 = jsonMessageDeserializer.Deserialize(r, type);
