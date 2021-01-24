                foreach (var message in transportMessageList)
            {
                MemoryStream ms = new MemoryStream();
                using (BsonDataWriter writer = new BsonDataWriter(ms))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(writer, message);
                }
                var bsonByteArray = ms.ToArray();
                Assert.True(bsonByteArray.Length!=0);
                bsonList.Add(bsonByteArray);
            }
            var deserializdTransmortMessageList = new List<TransportMessage>();
            foreach (var byteArray in bsonList)
            {
                TransportMessage message;
                MemoryStream ms = new MemoryStream(byteArray);
                using (BsonDataReader reader = new BsonDataReader(ms))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    message = serializer.Deserialize<TransportMessage>(reader);
                }
                Assert.True(message.Transportdata.Length!=0);
                deserializdTransmortMessageList.Add(message);
            }
