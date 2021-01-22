            //-------write to database-------------------------
            Person person = new Person();
            person.name = "Firstnm  Lastnm";
            MemoryStream memorystream = new MemoryStream(); 
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(memorystream, person);
            byte[] yourBytesToDb = memorystream.ToArray();
            //here you write yourBytesToDb to database
           
            //----------read from database---------------------
            //here you read from database binary data into yourBytesFromDb
            MemoryStream memorystreamd = new MemoryStream(yourBytesFromDb);
            BinaryFormatter bfd = new BinaryFormatter();
            Person deserializedperson = bfd.Deserialize(memorystreamd) as Person;
