            var stringReader = new System.IO.StringReader(System.IO.File.ReadAllText("path"));
            var serializer = new XmlSerializer(typeof(Group));
            var data = serializer.Deserialize(stringReader) as Group;
            // get all hubby of first person 
            var hubbies = data.Person[0].Hubby;
