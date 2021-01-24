    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "genericDrug", Namespace = "http://webservice.sirkb/")]
    public partial class returnDRUG
    {
        private string dOSAGEField;
        private ushort gENERIC_DRUG_IDField;
        private string gENERIC_DRUG_NAMEField;
        private string pHARMACEUTICAL_FORMField;
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.govtalk.gov.uk/CM/envelope")]
        public string DOSAGE
        {
            get
            {
                return this.dOSAGEField;
            }
            set
            {
                this.dOSAGEField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.govtalk.gov.uk/CM/envelope")]
        public ushort GENERIC_DRUG_ID
        {
            get
            {
                return this.gENERIC_DRUG_IDField;
            }
            set
            {
                this.gENERIC_DRUG_IDField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.govtalk.gov.uk/CM/envelope")]
        public string GENERIC_DRUG_NAME
        {
            get
            {
                return this.gENERIC_DRUG_NAMEField;
            }
            set
            {
                this.gENERIC_DRUG_NAMEField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.govtalk.gov.uk/CM/envelope")]
        public string PHARMACEUTICAL_FORM
        {
            get
            {
                return this.pHARMACEUTICAL_FORMField;
            }
            set
            {
                this.pHARMACEUTICAL_FORMField = value;
            }
        }
    }
