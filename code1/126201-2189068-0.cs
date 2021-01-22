    public class WarningType
    {
        public String oof;
    }
    public partial class SuccessType
    {
        private WarningType[][] warningsField;
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Warning", typeof(WarningType[]), IsNullable = false)]
        public WarningType[][] Warnings
        {
            get
            {
                return this.warningsField;
            }
            set
            {
                this.warningsField = value;
            }
        }
    }
