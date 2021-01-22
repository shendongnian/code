    public static class MetadataTypesRegister
    {
        static bool installed = false;
        static object installedLock = new object();
        public static void InstallForThisAssembly()
        {
            if (installed)
            {
                return;
            }
            lock (installedLock)
            {
                if (installed)
                {
                    return;
                }
                foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
                {
                    foreach (MetadataTypeAttribute attrib in type.GetCustomAttributes(typeof(MetadataTypeAttribute), true))
                    {
                        TypeDescriptor.AddProviderTransparent(
                            new AssociatedMetadataTypeTypeDescriptionProvider(type, attrib.MetadataClassType), type);
                    }
                }
                installed = true;
            }
        }
    }
