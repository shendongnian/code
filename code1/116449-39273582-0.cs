        /// <summary>
        /// Gets or sets the groups to which the computer is a member.
        /// </summary>
        [XmlArrayItem("Group")]
        public SerializableStringCollection Groups
        {
            get { return _Groups; }
            set { _Groups = value; }
        }
        private SerializableStringCollection _Groups = new SerializableStringCollection();
    
    <Groups>
       <Group>Test</Group>
       <Group>Test2</Group>
    </Groups>
