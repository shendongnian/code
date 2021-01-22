        [DataMember]
        public string ParamName // applies to all the properties, not just this one
        {
            get { return _name; }
            private set { _name = value; }
        }
