        public static XmlSerializer GetSerializer()
        {
            var lListOfBs = (from lAssembly in AppDomain.CurrentDomain.GetAssemblies()
                               from lType in lAssembly.GetTypes()
                               where typeof(B).IsAssignableFrom(lType)
                               select lType).ToArray();
            return new XmlSerializer(typeof(AList), lListOfBs);
        }
