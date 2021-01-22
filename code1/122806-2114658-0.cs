    [XmlType(Namespace="Myco.CLDatabaseBuilder.Models")]
    [XmlRoot(Namespace="Myco.CLDatabaseBuilder.Models", IsNullable=false)]
    public partial class Settings {
        private string sqlServerInstanceNameField;
        private string databaseNameField;
        private string rootDatabaseNameField;
        /// <remarks/>
        public string SqlServerInstanceName {
            get {
                return this.sqlServerInstanceNameField;
            }
            set {
                this.sqlServerInstanceNameField = value;
            }
        }
        /// <remarks/>
        public string DatabaseName {
            get {
                return this.databaseNameField;
            }
            set {
                this.databaseNameField = value;
            }
        }
        /// <remarks/>
        public string RootDatabaseName {
            get {
                return this.rootDatabaseNameField;
            }
            set {
                this.rootDatabaseNameField = value;
            }
        }
    }
