    public class AppSettings
    {
        public const decimal GILLS_PER_HOMER = 1859.771248601;
        public string HelpdeskPhone
        {
            get { // pulled from config and cached at startup }
        }
        public int MaxNumberOfItemsInAComboBox
        {
            get { return 3; }
        }
    }
