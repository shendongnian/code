    public class ApplicationSettings : ApplicationSettingsBase
    {
        public ApplicationSettings()
        {
            if( this.SomeIntArray == null )
                this.SomeIntArray = new int[] {1,2,3,4,5,6};
        }
        [UserScopedSetting()]
        [DefaultSettingValue("")]
        public int[] SomeIntArray
        {
            get
            {
                return (int[])this["SomeIntArray"];
            }
            set
            {
                this["SomeIntArray"] = (int[])value;
            }
        }
    }
