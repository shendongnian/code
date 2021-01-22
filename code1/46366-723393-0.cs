        public static IMyCompanySetting UnwrapSetting(XmlNode settingNode)
        {
            string typeName = settingNode.Attributes["type"].Value;
            string typeAssembly;
            if(settingNode.Attributes["assembly"] != null)
            {
                typeAssembly = settingNode.Attributes["assembly"].Value;
            }
            Type settingType = null;
            Assembly settingAssembly = null;
            try
            {
                // Create an object based on the type and assembly properties stored in the XML
                try
                {
                    settingAssembly = Assembly.Load(typeAssembly);
                    if (settingAssembly == null)
                    {
                        return null;
                    }
                }
                catch (Exception outerEx)
                {
                    try
                    {
                        settingType = GetOrphanType(typeName);
                    }
                    catch (Exception innerEx)
                    {
                        throw new Exception("Failed to create object " + typeName + " :: " + innerEx.ToString(), outerEx);
                    }
                }
                // We will try in order:
                // 1. Get the type from the named assembly.
                // 2. Get the type using its fully-qualified name.
                // 3. Do a deep search for the most basic name of the class.
                if (settingType == null && settingAssembly != null) settingType = settingAssembly.GetType(typeName);
                if (settingType == null) settingType = Type.GetType(typeName);
                if (settingType == null) settingType = GetOrphanType(typeName);
                if (settingType == null) throw new System.Exception(
                    String.Format("Unable to load definition for type {0} using loosest possible binding.", typeName));
            }
            catch (Exception ex)
            {
                throw new CometConfigurationException(
                    String.Format("Could not create object of type {0} from assembly {1}", typeName, typeAssembly), ex);
            }
            bool settingIsCreated = false;
            IMyCompanySetting theSetting = null;
            // If the class has a constructor that accepts a single parameter that is an XML node,
            // call that constructor.
            foreach (ConstructorInfo ctor in settingType.GetConstructors())
            {
                ParameterInfo[] parameters = ctor.GetParameters();
                if (parameters.Length == 1)
                {
                    if (parameters[0].ParameterType == typeof(XmlNode))
                    {
                        object[] theParams = { settingNode };
                        try
                        {
                            theSetting = (IMyCompanySetting)ctor.Invoke(theParams);
                            settingIsCreated = true;
                        }
                        catch (System.Exception ex)
                        {
                            // If there is a pre-existing constructor that accepts an XML node
                            // with a different schema from the one provided here, it will fail
                            // and we'll go to the default constructor.
                            UtilitiesAndConstants.ReportExceptionToCommonLog(ex);
                            settingIsCreated = false;
                        }
                    }
                }
            }
