            using (var file = File.OpenText(_fileWithGeom))
            {
                JsonReader reader = new JsonTextReader(file);
                while (reader.Read())
                {
                    while (Convert.ToString(reader.Value) != "features")
                    {
                        reader.Read();
                    }
                    Console.WriteLine("Found feature collections");
                    // ignore stuff until we get to attribute array
                    while (reader.Read())
                    {
                        switch (Convert.ToString(reader.Value))
                        {
                            case "attributes":
                                Console.WriteLine("Found feature");
                                reader.Read(); // get pass attributes property
         
                                do
                                {
                                    // As long as we're still in the attribute list...
                                    if (reader.TokenType == JsonToken.PropertyName)
                                    {
                                        var fieldName = Convert.ToString(reader.Value);
                                        reader.Read();
                                        Console.WriteLine("Name: {0}  Value: {1}", fieldName, reader.Value);
                                    }
                                    reader.Read();
                                } while (reader.TokenType != JsonToken.EndObject
                                         && Convert.ToString(reader.Value) != "attributes");
                                break;
                            case "geometry":
                                Console.WriteLine("Found geometry");
                                reader.Read();
                                break;
                        }
                    }
                }
            }
