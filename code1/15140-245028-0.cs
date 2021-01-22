        /// <summary>
        /// Score db record
        /// </summary>        
        [System.Xml.Serialization.XmlIgnore()]
        public int? ID 
        { 
            get 
            { 
                return iID_m; 
            } 
            set 
            { 
                iID_m = value; 
            } 
        }
        /// <summary>
        /// Score db record
        /// </summary>        
        [System.Xml.Serialization.XmlElement("ID",IsNullable = false)]
        public object IDValue
        {
            get
            {
                return ID;
            }
            set
            {
                if (value == null)
                {
                    ID = null;
                }
                else if (value is int || value is int?)
                {
                    ID = (int)value;
                }
                else
                {
                    ID = int.Parse(value.ToString());
                }
            }
        }
