    class Discover
    {
        public void DiscoverProperties()
        {
            var me = Assembly.GetExecutingAssembly().Location;
            var dir = Path.GetDirectoryName(me);
            var theClasses = dir + @"dllName.dll";
            var assembly = Assembly.LoadFrom(theClasses);
            var types = assembly.ExportedTypes.ToList();
            int propCount;
            string propertiesList;
            string cName;
            string tempString;
    
            foreach (var t in types)
            {
                propertiesList = "";
                propCount = 0;
                cName = t.Name;
    
                foreach (var prop in t.GetProperties())
                {
                    propCount++;
                    tempString = $"{prop.Name}:{prop.PropertyType.Name} ";
                    propertiesList = propertiesList += tempString;
                }
            }
        }
    }
