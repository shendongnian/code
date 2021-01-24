    public class AssembySettingSection : ConfigurationSection
    {
        public AssembySettingSection()
        {
            System.Console.WriteLine("new AssembySettingSection");
        }
        [ConfigurationProperty("settings", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(AssembySettingElement))]//Changed AssembySettingCollection to AssembySettingElement
        public AssembySettingCollection Settings
        {
            get
            {
                return base["settings"] as AssembySettingCollection;
            }
        }
    }
