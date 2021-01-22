    public class FolderConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("Folders", IsDefaultCollection = true)]
        public FolderConfigCollection Folders {
            get { return (FolderConfigCollection)base["Folders"]; }
        }
    }
    public class FolderConfigElement : ConfigurationElement {
        private const string ImportFolderConfigName = "ImportFolder";
        private const string FileTypesConfigName = "FileTypes";
        [ConfigurationProperty(ImportFolderConfigName, IsKey = true, IsRequired = true)]
        public string ImportFolder {
            get { return (string)this[ImportFolderConfigName]; } 
            set { this[ImportFolderConfigName] = value; }
        }
        [ConfigurationProperty(FileTypesConfigName, IsRequired = true)]
        public string FileTypes {
            get { return (string)this[FileTypesConfigName]; }
            set { this[FileTypesConfigName] = value; }
        }
    }
    [ConfigurationCollection(typeof(FolderConfigElement), AddItemName = "Folder",
     CollectionType=ConfigurationElementCollectionType.BasicMap)]
    public class FolderConfigCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement() {
            return new FolderConfigElement();
        }
        protected override object GetElementKey(ConfigurationElement element) {
            return (element as FolderConfigElement).ImportFolder;
        }
    }
