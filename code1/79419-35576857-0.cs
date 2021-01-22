          var dataContractSerializer = new System.Runtime.Serialization.DataContractSerializer(typeof(MyObject));
          byte[] serializedBytes;
            using (System.IO.MemoryStream mem1 = new System.IO.MemoryStream())
            {
                dataContractSerializer.WriteObject(mem1, results);
                serializedBytes = mem1.ToArray();
            }
            MyObject deserializedResult;
            using (System.IO.MemoryStream mem2 = new System.IO.MemoryStream(serializedBytes))
            {
                deserializedResult = (MyObject)dataContractSerializer.ReadObject(mem2);
            }
