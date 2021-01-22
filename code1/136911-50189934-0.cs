     using (FileStream fs = File.OpenRead(binarySourceFile.Path))
            using (BinaryReader reader = new BinaryReader(fs))
            {              
                // Read in all pairs.
                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {
                    Item item = new Item();
                    item.UniqueId = reader.ReadString();
                    item.StringUnique = reader.ReadString();
                    result.Add(item);
                }
            }
            return result;  
