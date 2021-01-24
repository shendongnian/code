    public class MetaInfo {
        /// <summary>
        /// Immutable class for holding PropertyInfo and XlsxColumn info.
        /// </summary>
        /// <param name="info">PropertyInfo</param>
        /// <param name="attr">XlsxColumn</param>
        public MetaInfo(PropertyInfo info, XlsxColumn attr) {
            PropertyInfo = info;
            Attribute = attr;
        }
    
        /// <summary>
        /// PropertyInfo. You may want to access the value inside the property.
        /// </summary>
        public PropertyInfo PropertyInfo { get; }
        /// <summary>
        /// Attribute. You may want to access information hold inside the attribute.
        /// </summary>
        public XlsxColumn Attribute { get; }
    }
