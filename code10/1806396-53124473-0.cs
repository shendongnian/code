        public static ObjectContext getObjectContext(string environment, bool isReadOnly)
        {
            environment = environment == null ? "" : environment.Trim();
            environment = environment.Length == 0 ? "" : (environment + ".");
            ObjectContext objectContext = new ObjectContext(
                    ConfigurationManager.ConnectionStrings[environment + _containerName].ToString());
            objectContext.DefaultContainerName = _containerName;
            objectContext.CommandTimeout = 0;
            objectContext.ContextOptions.ProxyCreationEnabled = !isReadOnly;
            return objectContext;
        }
