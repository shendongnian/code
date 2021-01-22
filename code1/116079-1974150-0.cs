    /// <summary>
        /// Holds mapping information between business objects properties and database table fields.
        /// </summary>
        [global::System.AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
        public sealed class DataFieldMappingAttribute : Attribute
        {
            /// <summary>
            /// Initializes a new instance of the DataFieldMappingAttribute class.
            /// </summary>
            /// <param name="fieldName">Name of the Field in Database Table that the business object properties maps to.</param>
            public DataFieldMappingAttribute(string fieldName)
            {
                this.MappedField = fieldName;
            }
    
            /// <summary>
            /// Gets or Sets the mapped Database Table Field.
            /// </summary>
            public string MappedField
            {
                get;
                private set;
            }
        }
