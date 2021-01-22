        public static XmlSerializer GetSerializer()
        {
            var lKnownTypes = (from lAssembly in AppDomain.CurrentDomain.GetAssemblies()
                               from lType in lAssembly.GetTypes()
                               where typeof(CommandToExecute).IsAssignableFrom(lType)
                               select lType).ToArray();
            return new XmlSerializer(typeof(Commands), lKnownTypes);
        }
